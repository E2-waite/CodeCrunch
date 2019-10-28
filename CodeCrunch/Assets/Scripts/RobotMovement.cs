using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    public float move_speed = 1.0f;
    public float fall_speed = 5.0f;
    public int x_pos, y_pos = 0;
    Grid grid_script;
    GameObject grid;    
    Vector3 move_target;
    Vector3 fall_target;
    bool moving = false;
    bool falling = false;

    void Start()
    {
        grid = GameObject.FindWithTag("Grid");
        grid_script = grid.GetComponent<Grid>();
    }

    void Update()
    {      
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move_target, Time.deltaTime * move_speed);
        }

        if (falling)
        {
            transform.position = Vector3.MoveTowards(transform.position, fall_target, Time.deltaTime * fall_speed);
        }

        if (transform.position == move_target)
        {
            if (transform.parent == null)
            {
                falling = true;
            }
            moving = false;
        }

        if (transform.position == fall_target)
        {
            // When robot has fallen off the edge respawn
            Respawn();
        }
    }

    public bool MoveRobot(int x_dir, int y_dir)
    {
        int x = x_pos + x_dir, y = y_pos + y_dir;
        if (grid_script.CheckTile(x, y))
        {
            // If tile is within the grid
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
                        // If robot is pushed, move this robot to pushed robot's old position
                        Movement(x, y);
                        return true;
                    }
                    return false;
                }
                return false;
            }
        }
        else
        {
            // If tile is not within grid fall off edge of the map
            Fall(x, y);
            return true;
        }
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

    void Fall(int x, int y)
    {
        transform.parent = null;
        move_target = new Vector3(x, 0.5f, y);
        fall_target = new Vector3(x, -20.0f, y);
        moving = true;
    }

    void Respawn()
    {

    }
}
