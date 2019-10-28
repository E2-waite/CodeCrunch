using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Command : MonoBehaviour
{
    public abstract void DoCommand();

    public CommandSpawnManager Csm;
    public RobotMovement Rm;
    private Vector3 spawnRange;
    public Text CommandText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

     void Update()
    {
        switch (Csm.commandToSpawn)
        {
            case 5:
               CommandText.text = ("Random()");
                break;
            case 4:
               CommandText.text = ("Left()");
                Rm.Left();
                break;
            case 3:
                CommandText.text = ("Right()");
                Rm.Right();
                break;
            case 2:
               CommandText.text = ("Back");
                Rm.Down();
                break;
            case 1:
               CommandText.text = ("Shoot");
                break;
            default:
                CommandText.text = ("Forward()");
                Rm.Forward();
                break;
        }


    }
}
