using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Repository : MonoBehaviour
{
    [SerializeField] private int RepositoryID;
    [SerializeField] private List<Cmd.CommandType> commandList;
    [SerializeField] private GameObject gameGrid;
    [SerializeField] private float commandDelay;

    public void addCommandToRepo(Cmd.CommandType _command)
    {
        commandList.Add(_command);
        gameGrid = GameObject.FindGameObjectWithTag("Grid");
    }

    public void doCommand()
    {
        StartCoroutine(DelayForCommands(commandDelay));
    }

    IEnumerator DelayForCommands(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        Debug.Log("Wait Over");
        int currentCommand = 0;
        if (commandList.Count > 0)
        {
            foreach (var cmd in commandList)
            {
                switch (cmd)
                {
                    case Cmd.CommandType.move:
                        {
                            Debug.Log("Command In List: " + currentCommand + ". The command is moving.");
                            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().MoveRobot(0, 1);
                            ++currentCommand;
                            break;
                        }
                    case Cmd.CommandType.rotateclockwise:
                        {
                            Debug.Log("Command In List: " + currentCommand + ". The command is rotate+");
                            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().RotateRobot(true);
                            ++currentCommand;
                            break;
                        }
                    case Cmd.CommandType.rotatecounterclockwise:
                        {
                            Debug.Log("Command In List: " + currentCommand + ". The command is rotate-");
                            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().RotateRobot(false);
                            ++currentCommand;
                            break;
                        }
                }
                yield return wait;
            }
        }
    }
}
