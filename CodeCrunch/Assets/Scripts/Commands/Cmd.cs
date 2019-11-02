using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd : MonoBehaviour
{
    [System.Serializable]public enum CommandType
    {
        none = -1,
        rotateclockwise,
        rotatecounterclockwise,
        move,
        missile
    }

    public CommandType cmd = Cmd.CommandType.move;
}
