using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveByTouch : MonoBehaviour
{
    float timeStep;
    float speed = 1;

    public bool selected = false;

    //public GameObject target;
    void Update()
    {
        timeStep += 0.03f * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider.CompareTag("Command"))
                { 
                    GameObject touchedObject = hit.transform.gameObject;
                    selected = true;
                }

                if (selected)
                {
                    Debug.Log("Moving!");
                    Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 1.0f));
                    transform.position = Vector3.MoveTowards(transform.position, target
                        , timeStep);

                   
                }
            }

            if(touch.phase == TouchPhase.Ended && selected)
            {
                selected = false;
                Debug.Log("User released cube");
            }


        }


    }
}
/*If user input touch is within sprite bounds, 
 * lerp position towards the input thats inside first. If released then fall down as normal */
