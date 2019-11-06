using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AssignPlayerNumber : MonoBehaviour
{

    public GameObject text;
    public GameObject FinishLine;

    private void Awake()
    {
        int winner = FinishLine.GetComponentInChildren<WinLose>().winnerNumber;
        string colour = "";

        switch(winner)
        {
            case 0:
                colour = "RED";
                break;
            case 1:
                colour = "BLUE";
                break;
            case 2:
                colour = "GREEN";
                break;
            case 3:
                colour = "YELLOW";
                break;
            default:
                break;
        }
        text.GetComponent<TextMeshProUGUI>().text = colour + " WINS!";
    }
}
