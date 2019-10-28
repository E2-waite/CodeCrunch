using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveByTouch : MonoBehaviour
{
    float timeStep;
    float speed = 1;

    public bool selected = false;

    public GameObject[] selectedObjects;
    void Update()
    {
        timeStep += 0.03f * Time.deltaTime;

        if (Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            for(int i = 0; i < Input.touchCount; ++i)
            {
                Touch touch = Input.GetTouch(i);

            }
        }


    }
}


//switch(i)
//{
//    case 0:
//        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 10f);
//        break;
//    case 1:
//        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 10f);
//        break;
//    case 2:
//        Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue, 10f);
//        break;
//    case 3:
//        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 10f);
//        break;
//    default:
//        break;
//}