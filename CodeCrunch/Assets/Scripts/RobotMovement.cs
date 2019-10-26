using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float move_speed = 1.0f;
    Grid grid_script;
    GameObject grid;
    public int x_pos, y_pos = 0;
    Vector3 move_target;
    bool moving = false;

    void Start()
    {
        grid = GameObject.FindWithTag("Grid");
        grid_script = grid.GetComponent<Grid>();
    }

    void Update()
    {
        if (Input.GetKeyUp("up"))
        {
            MoveRobot(0, 1);
        }
        if (Input.GetKeyUp("left"))
        {
            MoveRobot(-1, 0);
        }
        if (Input.GetKeyUp("down"))
        {
            MoveRobot(0, -1);
        }
        if (Input.GetKeyUp("right"))
        {
            MoveRobot(1, 0);
        }

        if(moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move_target, Time.deltaTime * move_speed);
        }

        if (transform.position == move_target)
        {
            moving = false;
        }
    }

    public bool MoveRobot(int x_dir, int y_dir)
    {
        if (grid_script.CheckTile(x_pos + x_dir, y_pos + y_dir) && !moving)
        { 
            transform.parent = null;
            transform.parent = grid_script.GetTile(x_pos + x_dir, y_pos + y_dir).transform;
            x_pos = x_pos + x_dir;
            y_pos = y_pos + y_dir;
            move_target = new Vector3(transform.parent.position.x, 0.6f, transform.parent.position.z);
            moving = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
