using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotData : MonoBehaviour
{
    public int player_num = 5;
    Renderer player_rend;
    GameObject[] colourRobot;
    bool colour_set;

    // Start is called before the first frame update
    void Awake()
    {
        player_rend = GetComponent<Renderer>();
    }

    public void SetPlayerNum(int num)
    {
        player_num = num;

       // colourRobot = GetComponentsInChildren<GameObject>();

        if (player_num == 0)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                
                r.material.color = Color.red;
            }
        }
        if (player_num == 1)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.blue;
            }
        }
        if (player_num == 2)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.green;
            }
        }
        if (player_num == 3)
        {
            foreach (Renderer r in GetComponentsInChildren<Renderer>())
            {
                r.material.color = Color.yellow;
            }
        }
    }

    public int GetPlayerNum()
    {
        return player_num;
    }
}
