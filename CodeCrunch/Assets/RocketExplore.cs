using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplore : MonoBehaviour
{
    public GameObject RocketExplosion;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot"))
        {
            Instantiate(RocketExplosion, collision.transform.position, Quaternion.identity);
            AudioManager.instance.Play("robotexplosion");
            collision.gameObject.SetActive(false);
            collision.gameObject.tag = "Untagged";
        }
    }
}
