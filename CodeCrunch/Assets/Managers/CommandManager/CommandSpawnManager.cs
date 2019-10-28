using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CommandSpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private float t;
    [SerializeField] private float maxCommands;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;

    public GameObject[] commands;
    private Vector3 spawnRange;
    public int commandToSpawn;
    public RobotMovement Rm;

    private GameObject uiCanvas;

    public Text CommandText;

    private void Start()
    {

        {
            uiCanvas = GameObject.FindGameObjectWithTag("Canvas");
        }

    }


    private void Update()
    {


    switch (commandToSpawn)
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


        if (t <= 0)
        {
            spawnRange = new Vector3(Random.Range(-100f, 100f), 0.75f, 0);
            commandToSpawn = Random.Range(0, commands.Length - 1);
            GameObject uiCommand = Instantiate(commands[commandToSpawn], spawnRange, Quaternion.identity, uiCanvas.transform);
            uiCommand.GetComponent<RectTransform>().localPosition = new Vector2(0f, 600f);
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            t = spawnTimer;

        }


        else
        {
            t -= Time.deltaTime;
        }




    }



}

