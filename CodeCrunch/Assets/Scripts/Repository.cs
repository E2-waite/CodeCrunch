using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    [SerializeField] private List<CommandType> commandList;

    public void addCommandToRepo(CommandType _command)
    {
        commandList.Add(_command);
    }
}
