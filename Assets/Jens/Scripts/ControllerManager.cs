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

    public static float GetTriggerFromPlayer(int player)
    {
        switch (player)
        {
            case 0:
                return Input.GetAxisRaw("TriggerJoystick1");
            case 1:
                return Input.GetAxisRaw("TriggerJoystick2");
            case 2:
                return Input.GetAxisRaw("TriggerJoystick3");
        }
        return 0.0f;
    }
}
