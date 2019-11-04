using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventTypes;

public class Repository : MonoBehaviour
{
    [SerializeField] private int RepositoryID;
    [SerializeField] private List<Cmd> commandList;
    [SerializeField] private GameObject gameGrid;

    public void addCommandToRepo(Cmd _command)
    {
        commandList.Add(_command);
        gameGrid = GameObject.FindGameObjectWithTag("Grid");
        Invoke("FindRobot", 1);
    }


    public void doCommand()
    {
        if(commandList.Count > 0)
        {
            //Switch statement to decide which function to call on robot.
            switch(commandList[0].cmd)
            {
                case Cmd.CommandType.move:
                {
                    gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().MoveRobot(0, 1);
                    break;
                }
                case Cmd.CommandType.rotate:
                {
                        //Deciding direction to turn.
                        bool clockwise = false;
                        if(commandList[0].rot == Cmd.RotationDirection.clockwise)
                        {
                            clockwise = true;
                        }
                        //End
                        gameGrid.GetComponent<Grid>().GetRobot(RepositoryID).GetComponent<RobotMovement>().RotateRobot(clockwise);
                        break;
                }
            }
            
        }
        
        
    }
}
