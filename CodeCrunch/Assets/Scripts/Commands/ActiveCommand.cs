using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCommand : MonoBehaviour
{
    [SerializeField] private CommandType myCommand;

    public CommandType GetCommand()
    {
        return myCommand;
    }
}
