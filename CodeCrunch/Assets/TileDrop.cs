using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDrop : MonoBehaviour
{
    bool active = false;
    public float countdown_time = 5.0f;
    float time_left;
    // Start is called before the first frame update
    void Start()
    {
        time_left = countdown_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0)
        {
            time_left -= 1 * Time.deltaTime;
            active = true;
        }
        else
        {
            time_left = countdown_time;
            active = false;
        }

        if (time_left <= 0)
        {
            DropTile();
        }
    }

    void DropTile()
    {
        if(transform.GetChild(0).gameObject.tag == "Robot")
        {
            GameObject robot = transform.GetChild(0).gameObject;
            RobotMovement robot_scr = robot.GetComponent<RobotMovement>();
            robot_scr.Fall(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.z));
            Destroy(this.gameObject);
        }
    }
}
