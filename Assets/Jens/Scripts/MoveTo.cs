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
        else if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + -transform.forward;
        }
        else
        {
            GetComponent<NavMeshAgent>().destination = transform.position;
        }

        if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) < -0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + -transform.right;
        }
        else if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + transform.right;
        }
        else if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) < 0.9f && ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) > -0.9f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position;
        }

        if (ControllerManager.GetHorizontalRightStickAxisFromPlayer(m_PlayerID) > 0.9f)
        {
            transform.Rotate(0, 2.5f, 0);
        }
        if (ControllerManager.GetHorizontalRightStickAxisFromPlayer(m_PlayerID) < -0.9f)
        {
            transform.Rotate(0, -2.5f, 0);
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
