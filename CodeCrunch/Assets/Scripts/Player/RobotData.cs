using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotData : MonoBehaviour
{
    int player_num;
    Renderer player_rend;
    bool colour_set;
    // Start is called before the first frame update
    void Start()
    {
        player_rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!colour_set)
        {
            if (player_num == 0)
            {
                player_rend.material.SetColor("_Color", Color.red);
                colour_set = true;
            }
            else if (player_num == 1)
            {
                player_rend.material.SetColor("_Color", Color.blue);
                colour_set = true;
            }
            else if (player_num == 2)
            {
                player_rend.material.SetColor("_Color", Color.green);
                colour_set = true;
            }
            else if (player_num == 3)
            {
                player_rend.material.SetColor("_Color", Color.yellow);
                colour_set = true;
            }
        }
    }

    public void SetPlayerNum(int num)
    {
        player_num = num;
    }

    public int GetPlayerNum()
    {
        return player_num;
    }
}
