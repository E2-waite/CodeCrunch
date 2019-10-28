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
        int x = x_pos + x_dir, y = y_pos + y_dir;
        if (grid_script.CheckTile(x, y))
        {
            if (grid_script.GetTile(x, y).transform.childCount == 0)
            {
                // If tile is empty, move to tile
                Movement(x, y);
                return true;
            }
            else
            {
                if (grid_script.GetTile(x, y).transform.GetChild(0).gameObject.tag == "Robot")
                {
                    // If tile is not empty, check if tile's child is robot
                    RobotMovement robot_scr = grid_script.GetTile(x, y).transform.GetChild(0).gameObject.GetComponent<RobotMovement>();
                    if (robot_scr.MoveRobot(x_dir, y_dir))
                    {
                        // If robot is pushed, move this robot to psuehd robot's old position
                        Movement(x, y);
                        return true;
                    }                    
                    return false;                  
                }
                return false;
            }
        }
        return false;
    }

    void Movement(int x, int y)
    {
        // Update this robot's position and parent
        transform.parent = null;
        transform.parent = grid_script.GetTile(x, y).transform;
        x_pos = x;
        y_pos = y;
        move_target = new Vector3(transform.parent.position.x, 0.5f, transform.parent.position.z);
        moving = true;
    }
}
