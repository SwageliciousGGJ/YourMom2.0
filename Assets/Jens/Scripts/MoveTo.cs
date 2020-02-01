using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    private Vector3 destination;
    public int m_PlayerID;

    void Update()
    {
        if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) < -0.2f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + transform.forward;
        }
        if (ControllerManager.GetVerticalAxisFromPlayer(m_PlayerID) > 0.2f)
        {
            GetComponent<NavMeshAgent>().destination = transform.position + -transform.forward;
        }
        if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) < -0.2f)
        {
            transform.Rotate(0, -1, 0);
        }
        if (ControllerManager.GetHorizontalAxisFromPlayer(m_PlayerID) > 0.2f)
        {
            transform.Rotate(0, 1, 0);
        }
    }
}
