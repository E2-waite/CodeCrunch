using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will handle all inputs from all different kinds of devices.

public class InputManager
{
    public static InputManager instance;

    public float JoystickHorizontal(int player_id)
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Horizontal_" + player_id.ToString());
        r += Input.GetAxis("K_Horizontal_" + player_id.ToString());
        return Mathf.Clamp(r, -1.0f, 1.0f);
    }
    public float JoystickVertical(int player_id)
    {
        float r = 0.0f;
        r += Input.GetAxis("J_Vertical_" + player_id.ToString());
        r += Input.GetAxis("K_Vertical_" + player_id.ToString());
        return r;
    }

    //Buttons
    public bool AButton(int player_id)
    {
        return Input.GetButtonDown("A_Button_" + player_id.ToString());
    }

    public bool AButtonUp(int player_id)
    {
        return Input.GetButtonUp("A_Button_" + player_id.ToString());
    }

    public bool BButton(int player_id)
    {
        return Input.GetButtonDown("B_Button_" + player_id.ToString());
    }

    public bool XButton(int player_id)
    {
       
        return Input.GetButtonDown("X_Button_" + player_id.ToString());
    }

    public bool XButtonUp(int player_id)
    {
        return Input.GetButtonUp("X_Button_" + player_id.ToString());
    }

    public bool YButton(int player_id)
    {
        return Input.GetButtonDown("Y_Button_" + player_id.ToString());
    }

    public float Horizontal()
    {
        float r = 0.0f;
        r = Input.GetAxis("Horizontal");
        return r;
    }
    public float Vertical()
    {
        float r = 0.0f;
        r = Input.GetAxis("Vertical");
        return r;
    }

    public bool KeyReleased_W()
    {
        return Input.GetButtonUp("Key_W");
    }

    public bool KeyReleased_S()
    {
        return Input.GetButtonUp("Key_S");
    }

    public bool KeyReleased_A()
    {
        return Input.GetButtonUp("Key_A");
    }

    public bool KeyReleased_D()
    {
        return Input.GetButtonUp("Key_D");
    }

    public bool KeyUp_Enter()
    {
      
        return Input.GetButtonUp("Key_Enter");
    }

    public bool Key_Space()
    {
        return Input.GetButton("Key_Space");

    }

    //Snes Pad
    public float NES_Vertical()
    {
        Debug.Log("NES Vertical: " + Input.GetAxis("NES_Vertical"));
        return Input.GetAxis("NES_Vertical");
    }

    public float NES_Horizontal()
    {
        Debug.Log("NES Vertical: " + Input.GetAxis("NES_Horizonal"));
        return Input.GetAxis("NES_Horizontal");
    }

    public bool DPAD_Up()
    {
        bool up = false;
        if(Input.GetAxisRaw("NES_Vertical") == -1)
        {
            up = true;
        }
        else
        {
            up = false;
        }
        return up;
    }

    public bool DPAD_Down()
    {
        bool down = false;
        if (Input.GetAxisRaw("NES_Vertical") == 1)
        {
            down = true;
        }
        else
        {
            down = false;
        }
        return down;
    }

    public bool NES_A()
    {
        return Input.GetButton("NES_A");

    }

    public bool NES_B()
    {
        return Input.GetButton("NES_B");

    }
}
