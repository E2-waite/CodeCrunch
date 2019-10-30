using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpin : MonoBehaviour
{
    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
