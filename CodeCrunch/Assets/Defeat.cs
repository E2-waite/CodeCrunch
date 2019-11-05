using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    private GameObject grid;
    [SerializeField] private GameObject defeatCanvas;

    private void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid");
    }

    void Update()
    {
        if(grid.GetComponent<Grid>().robots.Length <= 0)
        {

        }
    }
}
