﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningProjectile : MonoBehaviour
{
    [SerializeField]
    public Transform lookAtTransform;
    [SerializeField]
    public Transform spawn;
    [SerializeField]
    public bool hasBeenFired = false;
    [SerializeField]
    public LightningHands parent;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!hasBeenFired)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = spawn.position;
            transform.LookAt(lookAtTransform);
        }
        else
        {
            foreach (Transform t in transform)
            {
                if (transform.gameObject.layer != LayerMask.NameToLayer("Both"))
                    transform.gameObject.layer = LayerMask.NameToLayer("Both");
            }
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(500 * transform.forward);
        }
    }

    public void Fire()
    {
        hasBeenFired = true;
        transform.position = spawn.position;
        transform.LookAt(lookAtTransform);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(500 * transform.forward);
    }
    private void OnCollisionEnter(Collision collision)
    {
      
        if(collision.gameObject.tag == "Duck")
        {
            GameObject hittedEnemy = collision.gameObject;
            if (hittedEnemy.GetComponent<NPCMovement>())
            {
                Debug.Log("NPC Killed!");

                //Respawn this NPC and remove faith
                if (FaithController.m_Faith >= FaithController.damage)
                {
                    FaithController.m_Faith -= FaithController.damage;
                }
                else
                {
                    FaithController.m_Faith = 0;
                }
                hittedEnemy.GetComponent<NPCMovement>().Respawn();

            }
            else if (hittedEnemy.GetComponent<PlayerInteraction>())
            {
                Debug.Log("PLayer Killed!");
                hittedEnemy.GetComponent<PlayerInteraction>().Damage();
            }
        }
        else if(collision.gameObject.tag == "Temple")
        {
            if(collision.gameObject.GetComponentInChildren<Temple>())
            {
                collision.gameObject.GetComponentInChildren<Temple>().Heal();
            }
        }
        GetComponent<Rigidbody>().isKinematic = true;

        Debug.Log(collision.gameObject.name);
        hasBeenFired = false;
        parent.canShoot = true;
        gameObject.SetActive(false);
    }
}
