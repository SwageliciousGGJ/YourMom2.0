using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("UI Interaction")]
    public Text m_InteractableText;

    private GameObject m_InRangeTemple;
    private bool m_CanInteract = false;

    public bool m_IsDestroying = false;
    private float m_DestroyCounter = 0;

    void Start() {
        m_InteractableText.enabled = false;
    }

    void Update() {
        if (Input.GetButtonDown("TriggerJoystick1")) {
            if (m_CanInteract) {
                Interact();
            }
        }

        if (ControllerManager.GetTriggerFromPlayer(GetComponent<MoveTo>().m_PlayerID) > 0.2f) {
            GetComponent<Animator>().SetBool("bounce", true);
        }
        else {
            GetComponent<Animator>().SetBool("bounce", false);
        }

        if (m_IsDestroying) {
            m_DestroyCounter = m_DestroyCounter + Time.deltaTime;

            if (Input.GetButtonUp("TriggerJoystick1")) {
                m_IsDestroying = false;
                m_CanInteract = true;
            }

            if (m_DestroyCounter >= 3.0f) {
                m_InRangeTemple.GetComponent<Temple>().Attack(this.gameObject);
                m_IsDestroying = false;
                m_CanInteract = true;
            }
        }
    }

    public void Interact() {
        m_DestroyCounter = 0;
        m_CanInteract = false;
        m_InteractableText.text = "Operating..";
        m_IsDestroying = true;
    }

    public void OnCanInteractWithObject(GameObject a_Object) {
        m_InRangeTemple = a_Object;
        m_InteractableText.enabled = true;
        m_CanInteract = true;
    }

    public void OnDisableInteractWithObject(GameObject a_Object) {
        m_InRangeTemple = null;
        m_InteractableText.enabled = false;
        m_InteractableText.text = "Hold A to destroy";
        m_CanInteract = false;
    }
}
