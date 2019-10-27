using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCommand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Delete"))
        {
            Destroy(this.gameObject);
        }
    }
}
