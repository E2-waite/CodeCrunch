using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float countdown = 10.0f;
    public GameObject[] repositorys;

    private void Start()
    {
        foreach(var repository in repositorys)
        {
            repository.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if(countdown >= 0)
        {
            countdown -= Time.deltaTime;
        }
        else
        {
            countdown = 0;
        }
       
    }

}
