using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCommand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("delete"))
        {
            Destroy(this.gameObject);
        }
    }
}
