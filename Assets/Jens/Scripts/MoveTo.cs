using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public int m_PlayerID;
    public bool m_KeyboardMovement;
    public Transform m_CameraParent;

    void Update()
    {
        if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) < -0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + transform.forward;
        }
        if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + -transform.forward;
        }
        if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) < -0.9f)
        {
            transform.Rotate(0, -5, 0);
        }
        if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            transform.Rotate(0, 5, 0);
        }

        if (ControllerManager.GetHorizontalRightStickAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            m_CameraParent.Rotate(0, 5, 0);
        }
        if (ControllerManager.GetHorizontalRightStickAxisFromPlayer(m_PlayerID) < -0.9f)
        {
            m_CameraParent.Rotate(0, -5, 0);
        }

        /*
        if (GetComponent<Animator>().GetBool("isMoving"))
        {
            GetComponentInChildren<AudioSource>().Play();
        }
        else
        {
            GetComponentInChildren<AudioSource>().Stop();
        }
        */
    }
}
