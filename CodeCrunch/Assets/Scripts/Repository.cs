using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repository : MonoBehaviour
{
    [SerializeField] private int RepositoryID;
    [SerializeField] private List<CommandType> commandList;
    [SerializeField] private GameObject gameGrid;
    [SerializeField] private GameObject robot;


    public void addCommandToRepo(CommandType _command)
    {
        commandList.Add(_command);
        gameGrid = GameObject.FindGameObjectWithTag("Grid");
        Invoke("FindRobot", 1);
    }


    public void doCommand()
    {
        if(commandList.Count > 0)
        {

            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().MoveRobot(0, 1);
        }
        
        
    }

    void FindRobot()
    {

    }
}
