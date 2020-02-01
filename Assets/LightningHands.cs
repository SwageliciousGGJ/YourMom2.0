using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningHands : MonoBehaviour
{
    [SerializeField]
    Valve.VR.InteractionSystem.Hand hand;
    [SerializeField]
    DigitalRuby.LightningBolt.LightningBoltScript lightningBolt;
    [SerializeField]
    GameObject amingTarget;
    [SerializeField]
    public Valve.VR.SteamVR_Action_Boolean grabPinchAction = Valve.VR.SteamVR_Input.GetAction<Valve.VR.SteamVR_Action_Boolean>("GrabPinch");
    [SerializeField]
    public Valve.VR.SteamVR_Input_Sources handType;
    [SerializeField]
    bool canShoot = true;
    bool healing = false;
    [SerializeField]
    LayerMask mask;

    [SerializeField]
    Color healthColor, lightningColor;
    GameObject hittedEnemy = null, hittedTemple = null;

    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        hand = GetComponent<Valve.VR.InteractionSystem.Hand>();

    }
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity,mask))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                healing = false;
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.cyan);

                amingTarget.transform.position = hit.point + new Vector3(0, 0.05f, 0);
            }
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.transform.gameObject.tag == "Temple")
            {
                healing = true;
                hittedTemple = hit.transform.gameObject;
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.cyan);

                amingTarget.transform.position = hit.point + new Vector3(0, 0.05f, 0);
            }
            else if (hit.transform.gameObject.tag == "Duck")
            {
                healing = false;
                hittedEnemy = hit.transform.gameObject;
                Debug.Log("DUCCCK");
            }
        }
        if (canShoot)
        {
            if (grabPinchAction.GetStateDown(handType) || Input.GetKeyDown(KeyCode.Space))
            {
                if (healing)
                {
                    if (lightningBolt.GetComponent<LineRenderer>() != null)
                    {
                        lightningBolt.GetComponent<LineRenderer>().startColor = healthColor;
                        lightningBolt.GetComponent<LineRenderer>().endColor = healthColor;
                    }
                    Debug.Log("Healing");
                }
                else
                {
                    if (lightningBolt.GetComponent<LineRenderer>() != null)
                    {
                        lightningBolt.GetComponent<LineRenderer>().startColor = lightningColor;
                        lightningBolt.GetComponent<LineRenderer>().endColor = lightningColor;
                    }
                    Debug.Log("Killing");

                }
                lightningBolt.gameObject.SetActive(true);

                canShoot = false;

                StartCoroutine(Reset());

            }
        }
    }

    void Kill()
    {
        if (hittedEnemy != null)
        {
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
        else
        {
            Debug.Log("Ground hit!");
        }
    }

    void Heal()
    {
        if (hittedTemple)
        {
            hittedTemple.GetComponent<Temple>().Heal();
        }
    }

    IEnumerator Reset()
    {
        Kill();
        Heal();
        yield return new WaitForSeconds(1.0f);
        lightningBolt.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
