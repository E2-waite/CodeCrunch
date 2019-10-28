using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int num_robots;
    public int size_x = 4;
    public int size_y = 4;
    private GameObject[,] spaces;
    private GameObject[] robots;
    public GameObject floor_prefab;
    public GameObject robot_prefab;
    RobotMovement rob_mov;
    void Start()
    {
        spaces = new GameObject[size_x, size_y];

        // Sets up multidimensional array of grid tiles and sets their world position.
        for (int i = 0; i < size_y; i++)
        {
            for (int j = 0; j < size_x; j++)
            {
                spaces[j, i] = Instantiate(floor_prefab, new Vector3(j, 0, i), Quaternion.identity);
                spaces[j, i].transform.parent = this.transform;
                spaces[j, i].name = "Space " + i.ToString() + "," + j.ToString();
                GridData grid_data = spaces[j, i].GetComponent<GridData>();
                if (j == 0)
                {
                    grid_data.left = true;
                }
                if (j == size_x)
                {
                    grid_data.right = true;
                }
                if (i == 0)
                {
                    grid_data.bottom = true;
                }
                if (i == size_y)
                {
                    grid_data.top = true;
                }
            }
        }

        // Spawns robots in the centre of the first row of grid tiles.
        robots = new GameObject[num_robots];
        for (int i = 0; i < num_robots; i++)
        {
            int spawn_pos = ((size_x / 2) - (num_robots / 2)) + i;
            robots[i] = Instantiate(robot_prefab, new Vector3(spaces[spawn_pos, 0].transform.position.x, 0.5f, spaces[spawn_pos, 0].transform.position.z), Quaternion.identity);
            robots[i].name = "Player " + (i + 1).ToString();
            robots[i].transform.parent = spaces[spawn_pos, 0].transform;
            RobotMovement move_scr = robots[i].GetComponent<RobotMovement>();
            move_scr.x_pos = spawn_pos;
        }

        rob_mov = robots[0].GetComponent<RobotMovement>();
    }

    void Update()
    {
        if (Input.GetKeyUp("up"))
        {
            rob_mov.MoveRobot(0, 1);
        }
        if (Input.GetKeyUp("left"))
        {
            rob_mov.MoveRobot(-1, 0);
        }
        if (Input.GetKeyUp("down"))
        {
            rob_mov.MoveRobot(0, -1);
        }
        if (Input.GetKeyUp("right"))
        {
            rob_mov.MoveRobot(1, 0);
        }
    }

    public GameObject GetTile(int x, int y)
    {
        return spaces[x, y];
    }

    public bool CheckTile(int x, int y)
    {
        // Checks if entered tile is not outside of the grid, exists and does not have robot/obstacle on it.
        if (x < size_x && x >= 0 && y < size_y && y >= 0)
        {
            if (spaces[x, y] != null)
            {
                return true;           
            }
        }
        return false;
    }
}