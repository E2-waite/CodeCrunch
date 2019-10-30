using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Repository : MonoBehaviour
{
    [SerializeField] private int RepositoryID;
    [SerializeField] private List<Cmd.CommandType> commandList;
    [SerializeField] private GameObject gameGrid;

    public void addCommandToRepo(Cmd.CommandType _command)
    {
        commandList.Add(_command);
        gameGrid = GameObject.FindGameObjectWithTag("Grid");
    }

    public void doCommand()
    {
        if(commandList.Count > 0)
        {
            //Switch statement to decide which function to call on robot.

            for(int i = 0; i < commandList.Count; ++i)
            {
                switch (commandList[i])
                {
                    case Cmd.CommandType.move:
                    {
                        gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().MoveRobot(0, 1);
                        break;
                    }
                    case Cmd.CommandType.rotateclockwise:
                    {
                        gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().RotateRobot(true);
                        break;
                    }
                    case Cmd.CommandType.rotatecounterclockwise:
                    {
                        gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().RotateRobot(false);
                        break;
                    }
                }
            }    
        }
    }
}
