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
        if (t <= 0)
        {
            spawnRange = new Vector3(Random.Range(-100f, 100f), 0.75f, 0);
            int commandToSpawn = Random.Range(0, commands.Length);
            GameObject uiCommand;
            if (commandToSpawn == 0)
            {
                uiCommand = Instantiate(commands[commandToSpawn], spawnRange, Quaternion.Euler(new Vector3(0, 0, 0)), uiCanvas.transform);
            }
            else
            {
                uiCommand = Instantiate(commands[commandToSpawn], spawnRange, Quaternion.identity, uiCanvas.transform);
            }
            
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

