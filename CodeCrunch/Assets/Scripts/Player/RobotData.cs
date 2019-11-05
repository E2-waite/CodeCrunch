using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotData : MonoBehaviour
{
    public int player_num = 5;
    Renderer player_rend;
    bool colour_set;
    // Start is called before the first frame update
    void Start()
    {
        player_rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (!colour_set)
    //    {
    //        if (player_num == 0)
    //        {
    //            foreach (Renderer r in GetComponentsInChildren<Renderer>())
    //            {
    //               r.material.color = Color.red;
    //            }
    //            colour_set = true;
    //        }
    //        else if (player_num == 1)
    //        {
    //            foreach (Renderer r in GetComponentsInChildren<Renderer>())
    //            {
    //                r.material.color = Color.blue;
    //            }
    //            colour_set = true;
    //        }
    //        else if (player_num == 2)
    //        {
    //            foreach (Renderer r in GetComponentsInChildren<Renderer>())
    //            {
    //                r.material.color = Color.green;
    //            }
    //            colour_set = true;
    //        }
    //        else if (player_num == 3)
    //        {
    //            foreach (Renderer r in GetComponentsInChildren<Renderer>())
    //            {
    //                r.material.color = Color.yellow;
    //            }
    //            colour_set = true;
    //        }
    //    }
    //}

    public void SetPlayerNum(int num)
    {
        player_num = num;

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
