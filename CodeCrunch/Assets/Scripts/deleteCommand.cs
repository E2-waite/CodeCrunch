using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteCommand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("delete"))
        {
            Destroy(this.gameObject);
        }
    }
}
