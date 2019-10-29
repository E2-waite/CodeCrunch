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
    [SerializeField] GameObject players;

    private Camera cam;

    void Start()
    {
        //Set active camera
        cam = GetComponent<Camera>();

        //Find Game object with player and assign it with the players prefab gameobject.
        players = GameObject.FindGameObjectWithTag("Robot");

        //Add all active players to active multi-cam. This will get the children from the Players gameobject.
        for(int i = 0; i < players.transform.childCount; ++i)
        {
                targets.Add(players.transform.GetChild(i));    
        }
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
}
