using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    private GameObject grid;
    [SerializeField] private GameObject defeatCanvas;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject[] repositorys;
    [SerializeField] private GameObject SpawnManager;

    private void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    void Update()
    {
        int null_count = 0;

        foreach(var robot in grid.GetComponent<Grid>().robots)
        {
            if(robot == null)
            {
                null_count++;
            }
        }

        if(null_count == 4)
        {
            defeatCanvas.SetActive(true);
            Destroy(winCanvas);
            foreach (var repo in repositorys)
            {
                repo.SetActive(false);
            }
            var allCommands = GameObject.FindGameObjectsWithTag("Command");
            foreach (GameObject cmd in allCommands)
            {
                Destroy(cmd);
            }
            SpawnManager.SetActive(false);
        }
    }
}
