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
    public float m_TimeToDestroy = 3;

    [Header("Temple destroy variables")]
    public ParticleSystem m_DestroyParticle;

    [Header("Temple Sounds")]
    public AudioClip m_SoundCracking;

    [Header("Health")]
    public TempleState m_TemplateState = TempleState.TempleState_Alive;
    private GameObject m_PlayerThatDestroys;

    public void Attack(GameObject a_AttackObject) {
        m_PlayerThatDestroys = a_AttackObject;
        m_PlayerThatDestroys.GetComponent<SinglePlayerStats>().m_Points += m_ReceivedDestroyCurrency;
        m_PlayerThatDestroys.GetComponent<PlayerInteraction>().m_InteractableImage.SetActive(false);

        m_TemplateState = TempleState.TempleState_Dead;

        if (m_DestroyParticle) {
            m_DestroyParticle.Stop();
        }

        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(m_SoundCracking);
    }

    public void Heal() {
        if (m_TemplateState == TempleState.TempleState_Dead) {
            m_TemplateState = TempleState.TempleState_Alive;

            if (m_DestroyParticle) {
                m_DestroyParticle.Play();
            }
        }

        GetComponent<AudioSource>().Play();
    }

    void OnTriggerStay(Collider other) {
        if (other.gameObject.GetComponent<PlayerInteraction>()) {
            if(!other.gameObject.GetComponent<PlayerInteraction>().m_IsDestroying && m_TemplateState == TempleState.TempleState_Alive)
                other.gameObject.GetComponent<PlayerInteraction>().OnCanInteractWithObject(this.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.GetComponent<PlayerInteraction>()) {
            other.gameObject.GetComponent<PlayerInteraction>().OnDisableInteractWithObject(this.gameObject);
        }
    }
}
