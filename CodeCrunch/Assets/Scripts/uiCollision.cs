﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision/Trigger");
        if (other.gameObject.CompareTag("Command"))
        {
            if(other.gameObject.GetComponent<OnUITouch>().dragging)
            {
                GetComponent<Repository>().addCommandToRepo(other.gameObject.GetComponent<ActiveCommand>().GetCommand());
                Destroy(other.gameObject);
            }
        }
    }
}
