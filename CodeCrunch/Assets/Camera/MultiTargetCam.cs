using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiTargetCam : MonoBehaviour
{
    public List<Transform> targets;
    public Vector3 offset;

    private Vector3 velocity;
    [SerializeField] private float smoothTime;

    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    [SerializeField] private float zoomLimit;


    //This gets a gameObject with all the players as child objects. e.g. a prefab with 2-4 child objects
    [SerializeField]private GameObject[] allRobots;
    [SerializeField] private GameObject[] allLasers;

    public Camera cam;
    public Camera cam2;

    public GameObject winScript;

    void Start()
    {
        // Set active camera
        cam.enabled = true;
        cam2.enabled = false;

        //cam = Camera.main;
       
        //Add all active players to active multi-cam. This will get the children from the Players gameobject.
        Invoke("FindRobots", 1);
        Invoke("FindLasers", 1);

        winScript = GameObject.Find("WinnerMenu");
    }

    private void Update()
    {
        StartCoroutine(WaitToChangeCam());

        for (int i = 0; i < targets.Count; ++i)
        {
            if (targets[i].gameObject.tag == "Untagged")
            {
              targets.Remove(targets[i]);
            }
        }

        winScript = GameObject.Find("WinnerMenu");
    }

    IEnumerator WaitToChangeCam()
    {
        yield return new WaitForSeconds(10);
        cam.enabled = false;
        cam2.enabled = true;
    }
    //Late update because we want to move the camera after everything else so it moves correctly.
    private void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return;
        }

        MoveCam();
        Zoom();

        // Changes back to orignal cam when won
        if(winScript != null)
        {
            if (winScript.activeSelf.Equals(true))
            {
                cam.enabled = true;
                cam2.enabled = false;
            }
        }
    }

    void MoveCam()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDist() / zoomLimit);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    //This gets the centre point of the furthest and closest players and creates a bounding box which has a centre.
    Vector3 GetCenterPoint()
    {
        if(targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for(int i = 0; i < targets.Count; ++i)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    //Calculates what the greatest distance between all the players is and returns the biggest.
    float GetGreatestDist()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; ++i)
        {
            bounds.Encapsulate(targets[i].position);
        }
        return bounds.size.x;
    }

    private void FindRobots()
    {
        allRobots = GameObject.FindGameObjectsWithTag("Robot");
        var robotCount = allRobots.Length;

        foreach (var obj in allRobots)
        {
            targets.Add(obj.transform);
        }


    }
    private void FindLasers()
    {
        allLasers = GameObject.FindGameObjectsWithTag("Laser");
        var laserCount = allLasers.Length;

        foreach (var obj in allLasers)
        {
            targets.Add(obj.transform);
        }


    }
}


