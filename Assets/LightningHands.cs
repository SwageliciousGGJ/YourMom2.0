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
    [SerializeField]
    LayerMask mask;

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
                Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.cyan);

                amingTarget.transform.position = hit.point + new Vector3(0, 0.01f, 0);
            }
            else
            {
                Debug.Log(hit.transform.gameObject.layer);
            }
        }
        if (canShoot)
        {
            if (grabPinchAction.GetStateDown(handType))
            {
                lightningBolt.gameObject.SetActive(true);
                canShoot = false;
                StartCoroutine(Reset());
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1.0f);
        lightningBolt.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
}
