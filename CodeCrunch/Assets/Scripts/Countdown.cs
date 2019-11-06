using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float countdown = 15.0f;
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
            if(countdown < 4 && countdown > 3)
            {
                AudioManager.instance.Play("countdown");
            }
            else if (countdown < 3 && countdown > 2)
            {
                AudioManager.instance.Play("countdown");
            }
            else if (countdown < 2 && countdown > 1)
            {
                AudioManager.instance.Play("countdown");
            }

        }
        else
        {
            countdown = 0;
        }
    }

}
