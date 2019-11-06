using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Command"))
        {
            if(other.gameObject.GetComponent<OnUITouch>().dragging)
            {
                GetComponent<Repository>().addCommandToRepo(other.gameObject.GetComponent<Cmd>().cmd);
                Destroy(other.gameObject);
            }
        }
    }
}
