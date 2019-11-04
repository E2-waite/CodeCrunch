using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpin : MonoBehaviour
{
    bool activated = false;

    void Update()
    {
        if (transform.childCount > 0)
        {
            if (!activated)
            {
                if (transform.GetChild(0).gameObject.tag == "Robot")
                {
                    GameObject robot = transform.GetChild(0).gameObject;
                    RobotMovement robot_scr = robot.GetComponent<RobotMovement>();
                    if (robot_scr.RotateRobot(Random.value > 0.5f))
                    {
                        activated = true;
                    }
                }
            }
        }
        else
        {
            activated = false;
        }
    }
}
