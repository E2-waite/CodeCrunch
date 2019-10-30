using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmd : MonoBehaviour
{
    [System.Serializable]public enum CommandType
    {
        rotate,
        move
    }

    [System.Serializable] public enum RotationDirection
    {
        clockwise = 0,
        anticlockwise = 1
    }

    public CommandType cmd;
    public RotationDirection rot;
}
