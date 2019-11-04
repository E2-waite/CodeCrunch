using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserWallMovement : MonoBehaviour
{
    [Range( 2.0f, 20f)]
    public int speed;

    public float Timer;
    public float MaxTime = 10;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        Timer = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer += Time.deltaTime;

        if(Timer > MaxTime)
        {
            rb.AddForce(transform.forward * speed);
            Timer = 0;
          
        }

        

    }


    void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(other.gameObject);
            }
        }
}


