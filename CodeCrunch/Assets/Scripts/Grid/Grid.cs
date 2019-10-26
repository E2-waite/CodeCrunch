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

    void Start()
    {
        spaces = new GameObject[size_x, size_y];

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

        robots = new GameObject[num_robots];
        for (int i = 0; i < num_robots; i++)
        {
            robots[i] = Instantiate(robot_prefab, new Vector3(0, 0, 0), Quaternion.identity);
            robots[i].transform.parent = spaces[i, 0].transform;
            robots[i].transform.position = spaces[i, 0].transform.position;
            RobotMovement move_scr = robots[i].GetComponent<RobotMovement>();
            move_scr.x_pos = i;
        }
    }

    public GameObject GetTile(int x, int y)
    {
        return spaces[x, y];
    }

    public bool CheckTile(int x, int y)
    {
        if (x < size_x && x >= 0 && y < size_y && y >= 0)
        {
            if (spaces[x, y] != null)
            {
                if (spaces[x, y].transform.childCount == 0)
                {
                    return true;
                }              
            }
        }
        return false;
    }
}