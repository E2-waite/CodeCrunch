using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Repository : MonoBehaviour
{
    public int RepositoryID;
    public List<Cmd.CommandType> commandList;
    [SerializeField] private GameObject gameGrid;
    private float commandDelay = 1.5f;

    public void addCommandToRepo(Cmd.CommandType _command)
    {
        commandList.Add(_command);
        gameGrid = GameObject.FindGameObjectWithTag("Grid");
    }

    public void doCommand()
    {
        StartCoroutine(DelayForCommands(commandDelay));
    }

    public void EmptyCommands()
    {
        if (commandList.Count > 0)
        {
            commandList.Clear();
        }
    }

    IEnumerator DelayForCommands(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);
        Debug.Log("Wait Over");
        int currentCommand = 1;
        if (commandList.Count > 0)
        {
            foreach (var cmd in commandList)
            {
                switch (cmd)
                {
                    case Cmd.CommandType.move:
                        {
                            Debug.Log("Command In List: " + currentCommand + ". The command is moving.");
                            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().MoveForward();
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
                    case Cmd.CommandType.missile:
                        {
                            Debug.Log("Command In List: " + currentCommand + ". The command is Missile");
                            gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().FireRocket();
                            ++currentCommand;
                            break;
                        }

                }
                yield return wait;
            }
            EmptyCommands();

        }
    }
}
