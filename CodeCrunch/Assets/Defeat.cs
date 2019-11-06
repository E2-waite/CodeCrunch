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
    bool lose_music = false;

    private void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    void Update()
    {
        int null_count = 0;

        foreach(var robot in grid.GetComponent<Grid>().robots)
        {
            if(robot.tag == "Untagged")
            {
                null_count++;
            }
        }

        if(null_count == 4)
        {
            defeatCanvas.SetActive(true);
            Destroy(winCanvas);

            var allCommands = GameObject.FindGameObjectsWithTag("Command");
            foreach (GameObject cmd in allCommands)
            {
                Destroy(cmd);
            }
            SpawnManager.SetActive(false);
            if(!lose_music)
            {
                lose_music = true;
                AudioManager.instance.Play("lose");
            }
            AudioManager.instance.Stop("background_song");
            foreach (var repo in repositorys)
            {
                if (repo != null)
                    repo.SetActive(false);
            }
        }
    }
}
