using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    bool target_set = false;
    GameObject target;
    Vector3 target_pos;
    public float smooth;
    public float shot_speed;

    void Start()
    {
        target_pos = target.transform.position;
    }

    public void SetTarget(GameObject robot)
    {
        target = robot;
        target_set = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(target_set)
        {
            SmoothLookAt(target.transform.position);
            transform.position = Vector3.Lerp(transform.position, target.transform.position ,shot_speed * Time.deltaTime);
        }

        if (transform.position == target.transform.position)
        {
            // Explode
            Destroy(this.gameObject);
        }
    }

    void SmoothLookAt(Vector3 target)
    {
        Vector3 dir = target - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
    }
}
