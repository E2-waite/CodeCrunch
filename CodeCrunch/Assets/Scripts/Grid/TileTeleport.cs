using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTeleport : MonoBehaviour
{
    bool activated = false;

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
                    if (robot.transform.position.x == transform.position.x &&
                        robot.transform.position.z == transform.position.z)
                    {
                        RobotMovement robot_scr = robot.GetComponent<RobotMovement>();
                        if (robot_scr.Respawn())
                        {
                            activated = true;
                        }
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
