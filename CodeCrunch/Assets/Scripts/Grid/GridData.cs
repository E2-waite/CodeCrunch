using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using enums;

public class GridData : MonoBehaviour
{
    int player_num;
    GameObject grid;
    Grid grid_scr;
    Renderer tile_rend;
    public TILE tile_type;
    void Start()
    {
        grid = transform.parent.gameObject;
        grid_scr = grid.GetComponent<Grid>();
        tile_rend = GetComponent<Renderer>();
    }

    void Update()
    {
        if (transform.childCount > 0)
        {
            if (transform.GetChild(0).gameObject == grid_scr.GetRobot(0))
            {
                tile_rend.material.SetColor("_Color", Color.red);
            }
            else if (transform.GetChild(0).gameObject == grid_scr.GetRobot(1))
            {
                tile_rend.material.SetColor("_Color", Color.blue);
            }
            else if (transform.GetChild(0).gameObject == grid_scr.GetRobot(2))
            {
                tile_rend.material.SetColor("_Color", Color.green);
            }
            else if (transform.GetChild(0).gameObject == grid_scr.GetRobot(3))
            {
                tile_rend.material.SetColor("_Color", Color.yellow);
            }            
        }
        else
        {
            if (tile_type == TILE.normal)
            {
                tile_rend.material.SetColor("_Color", Color.grey);
            }
            else if(tile_type == TILE.spin)
            {
                tile_rend.material.SetColor("_Color", new Color32(254, 161, 0, 1));
            }
            else if (tile_type == TILE.teleport)
            {
                tile_rend.material.SetColor("_Color", new Color32(143, 0, 254, 1));
            }
            else if (tile_type == TILE.fall)
            {
                tile_rend.material.SetColor("_Color", new Color32(255, 100, 100, 1));
            }
        }
    }
}
