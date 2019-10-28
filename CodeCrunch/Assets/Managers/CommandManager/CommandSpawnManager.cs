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

    private void Start()
    {

    }


    private void Update()
    {
        if (t <= 0)
        {
            spawnRange = new Vector3(Random.Range(-1f, 1f), 0.75f, 0);
            commandToSpawn = Random.Range(0, commands.Length - 1);
            Instantiate(commands[commandToSpawn], spawnRange, Quaternion.identity);
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            t = spawnTimer;

          
        }

        else
        {
            t -= Time.deltaTime;
        }
    }





}


