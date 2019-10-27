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
    public Text CommandText;
    // private int commandToSpawn;

    private void Start()
    {

    }


    private void Update()
    {
        if (t <= 0)
        {
            spawnRange = new Vector3(Random.Range(-1f, 1f), 0.75f, 0);
            int commandToSpawn = Random.Range(0, commands.Length - 1);
            Instantiate(commands[commandToSpawn], spawnRange, Quaternion.identity);
            spawnTimer = Random.Range(minSpawnTime, maxSpawnTime);
            t = spawnTimer;

            switch (commandToSpawn)
            {
                case 5:
                    CommandText.text = ("Forward()");
                    break;
                case 4:
                    CommandText.text = ("Left()");
                    break;
                case 3:
                    CommandText.text = ("Right()");
                    break;
                case 2:
                    CommandText.text = ("Back");
                    break;
                case 1:
                    CommandText.text = ("Ulg, glib, Pblblblblb");
                    break;
                default:
                    CommandText.text = ("Incorrect intelligence level.");
                    break;
            }
        }

        else
        {
            t -= Time.deltaTime;
        }
    }





}


