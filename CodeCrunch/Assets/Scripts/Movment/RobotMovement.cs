using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    private enum Direction { up, right, down, left };
    public float move_speed = 1.0f;
    public float fall_speed = 5.0f;
    public float turn_speed = 2.0f;
    public float shot_cooldown = 2.0f;
    public int x_pos, y_pos = 0;
    public GameObject rocket_prefab;
    Grid grid_script;
    GameObject grid;    
    Vector3 move_target;
    Vector3 fall_target;
    bool moving = false;
    bool falling = false;
    bool turning = false;
    bool can_fire = true;
    Direction direction = Direction.up;
    RobotData data_scr;
    void Start()
    {
        grid = GameObject.FindWithTag("Grid");
        grid_script = grid.GetComponent<Grid>();
        data_scr = GetComponent<RobotData>();
    }

    void Update()
    {
        if (Input.GetKeyUp("w"))
        {
            MoveForward();
        }
        if (Input.GetKeyUp("a"))
        {
            RotateRobot(false);
        }
        if (Input.GetKeyUp("d"))
        {
            RotateRobot(true);
        }
        UpdatePosition();
    }

    public bool MoveForward()
    {
        switch(direction)
        {
            default:
            {
                return false;
                break;
            }
            case Direction.up:
            {
                return MoveRobot(0, 1);
                break;
            }
            case Direction.right:
            {
                return MoveRobot(1, 0);
                break;
            }
            case Direction.down:
            {
                return MoveRobot(0, -1);
                break;
            }
            case Direction.left:
            {
                return MoveRobot(-1, 0);
                break;
            }
        }
    }

    public bool RotateRobot(bool clockwise)
    {
        if (!moving && !turning && !falling)
        {
            if(clockwise)
            {
                StartCoroutine(RotateMe(Vector3.up * 90, 0.5f));
                if (direction == Direction.left)
                {
                    direction = Direction.up;
                }
                else
                {
                    direction++;
                }
            }
            else
            {
                StartCoroutine(RotateMe(Vector3.up * -90, 0.5f));
                if (direction == Direction.up)
                {
                    direction = Direction.left;
                }
                else
                {
                    direction--;
                }
            }
            return true;
        }
        return false;
    }

    IEnumerator RotateMe(Vector3 byAngles, float inTime)
    {
        turning = true;
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }
        transform.rotation = toAngle;
        turning = false;
    }

    public bool MoveRobot(int x_dir, int y_dir)
    {
        int x = x_pos + x_dir, y = y_pos + y_dir;
        if (!moving && !falling && !turning)
        {
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

    public void Fall(int x, int y)
    {
        transform.parent = null;
        move_target = new Vector3(x, 0.5f, y);
        fall_target = new Vector3(x, -10.0f, y);
        moving = true;
    }

    public bool FireRocket()
    {
        if (can_fire)
        {
            StartCoroutine(RocketSequence());
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator RocketSequence()
    {
        can_fire = false;
        GameObject rocket = Instantiate(rocket_prefab, transform.position, Quaternion.identity);
        Rocket rocket_scr = rocket.GetComponent<Rocket>();
        rocket_scr.SetTarget(grid_script.GetFirst(data_scr.GetPlayerNum()));
        yield return new WaitForSeconds(shot_cooldown);
        can_fire = true;
    }
   
    public bool Respawn()
    {
        // Set robot's parent to random free tile on row below where they died
        falling = true;
        moving = false;
        transform.parent = null;
        transform.parent = grid_script.GetFreeTile(y_pos).transform;
        x_pos = Mathf.RoundToInt(transform.parent.position.x);
        y_pos = Mathf.RoundToInt(transform.parent.position.z);
        transform.position = new Vector3(transform.parent.position.x, 10.0f, transform.parent.position.z);
        fall_target = new Vector3(transform.parent.position.x, 0.5f, transform.parent.position.z);
        return true;
    }

    void UpdatePosition()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, move_target, Time.deltaTime * move_speed);
        }
        if (falling)
        {
            transform.position = Vector3.MoveTowards(transform.position, fall_target, Time.deltaTime * fall_speed);
        }

        // If the robot has no parent, it is falling off the grid
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
            if (transform.parent == null)
            {
                Respawn();
            }
            else
            {
                falling = false;
            }
        }
    }
}
