using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winner : MonoBehaviour
{
    public GameObject WinnerMenu;
    public GameObject[] Repositorys;
    public GameObject Spawnmanager;
    bool displayWinnerMenu = false;
    float timerDelay = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot"))
        {
            displayWinnerMenu = true;
        }
    }

    private void Update()
    {
        if (displayWinnerMenu)
        {
            timerDelay -= Time.deltaTime;
            if (timerDelay <= 0)
            {
                WinnerMenu.SetActive(true);
                foreach(var repo in Repositorys)
                {
                    repo.SetActive(false);
                }
                var allCommands = GameObject.FindGameObjectsWithTag("Command");
                foreach(GameObject cmd in allCommands)
                {
                    Destroy(cmd);
                }
                Spawnmanager.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
