using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteAfterComplete : MonoBehaviour
{
    private ParticleSystem[] ps;
    [SerializeField] private float Timer = 4.0f;


    public void Start()
    {
        ps = GetComponentsInChildren<ParticleSystem>();
    }

    public void Update()
    {
        if(Timer <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            Timer -= Time.deltaTime;
        }
    }
}
