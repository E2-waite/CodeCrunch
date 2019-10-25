using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int size_x = 4;
    public int size_y = 4;
    private GameObject[,] spaces;
    public GameObject floor_prefab;
    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
