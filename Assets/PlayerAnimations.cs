using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField]
    Animator playerAnimator;
    [SerializeField]
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentVelocity = agent.velocity;
        Vector3 normalized = agent.velocity.normalized;
        float vectorLength = currentVelocity.magnitude;
        float speed = Mathf.Abs(vectorLength);
        Debug.Log(currentVelocity);
        if(speed < -0.5f || speed > 0.5f)
        {
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }
}
