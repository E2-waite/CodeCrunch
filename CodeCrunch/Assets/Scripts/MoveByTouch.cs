using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveByTouch : MonoBehaviour
{
    float timeStep;
    float speed = 1;

    //public GameObject target;
    void Update()
    {
        timeStep += 0.03f * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                { 
                    GameObject touchedObject = hit.transform.gameObject;

                    Debug.Log("Touched " + touchedObject.transform.name);
                }
            }
        }

    }
}
/*If user input touch is within sprite bounds, 
 * lerp position towards the input thats inside first. If released then fall down as normal */
