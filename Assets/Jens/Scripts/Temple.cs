using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TempleState
{
    TempleState_Alive,
    TempleState_Dead
}

public class Temple : MonoBehaviour {

    [Header("Temple variables")]
    public int m_CurrencyOverTime;
    public int m_ReceivedDestroyCurrency;

    [Header("Health")]
    public TempleState m_TemplateState = TempleState.TempleState_Alive;
    private GameObject m_PlayerThatDestroys;

    public void Attack(GameObject a_AttackObject) {
        m_PlayerThatDestroys = a_AttackObject;
        m_PlayerThatDestroys.GetComponent<PlayerInteraction>().m_InteractableText.enabled = false;
        m_PlayerThatDestroys.GetComponent<PlayerInteraction>().m_InteractableText.text = "E";
        m_PlayerThatDestroys.GetComponent<SinglePlayerStats>().m_Points += m_ReceivedDestroyCurrency;

        m_TemplateState = TempleState.TempleState_Dead;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void Heal() {
        if (m_TemplateState == TempleState.TempleState_Dead) {
            m_PlayerThatDestroys.GetComponent<PlayerInteraction>().m_InteractableText.enabled = false;
            m_PlayerThatDestroys.GetComponent<PlayerInteraction>().m_InteractableText.text = "E";
            m_TemplateState = TempleState.TempleState_Alive;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<PlayerInteraction>()) {
            if(!other.gameObject.GetComponent<PlayerInteraction>().m_IsDestroying)
                other.gameObject.GetComponent<PlayerInteraction>().OnCanInteractWithObject(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<PlayerInteraction>()) {
            if (!other.gameObject.GetComponent<PlayerInteraction>().m_IsDestroying)
                other.gameObject.GetComponent<PlayerInteraction>().OnDisableInteractWithObject(this.gameObject);
        }
    }
}
