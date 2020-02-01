using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static float GetHorizontalAxisFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetAxisRaw("Horizontal");
            case 1:
                return Input.GetAxisRaw("Horizontal2");
            case 2:
                return Input.GetAxisRaw("Horizontal3");
        }
        return 0.0f;
    }
    public static float GetVerticalAxisFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetAxisRaw("Vertical");
            case 1:
                return Input.GetAxisRaw("Vertical2");
            case 2:
                return Input.GetAxisRaw("Vertical3");
        }
        return 0.0f;
    }

    public static bool GetAButtonFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetButtonDown("AJoystick");
            case 1:
                return Input.GetButtonDown("AJoystick2");
            case 2:
                return Input.GetButtonDown("AJoystick3");
        }
        return false;
    }

    public static bool GetAButtonDownFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetButton("AJoystick");
            case 1:
                return Input.GetButton("AJoystick2");
            case 2:
                return Input.GetButton("AJoystick3");
        }
        return false;
    }

    public static bool GetAButtonUpFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetButtonUp("AJoystick");
            case 1:
                return Input.GetButtonUp("AJoystick2");
            case 2:
                return Input.GetButtonUp("AJoystick3");
        }
        return false;
    }
}
