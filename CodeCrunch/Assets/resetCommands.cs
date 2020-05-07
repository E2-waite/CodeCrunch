using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCommands : MonoBehaviour
{

    GameObject grid_script;
    Repository repository;

    private void Start()
    {
        grid_script = GameObject.FindGameObjectWithTag("Grid");
        repository = GetComponent<Repository>();
    }

    void Update()
    {
        if(grid_script.GetComponent<Grid>().robots[repository.RepositoryID].GetComponent<RobotMovement>().falling)
        {
            repository.EmptyCommands();
        }
    }
}
