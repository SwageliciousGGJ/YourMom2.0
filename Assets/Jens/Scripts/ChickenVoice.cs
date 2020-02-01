using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenVoice : MonoBehaviour
{
    public AudioClip[] randomAudiosources;
    void Update()
    {
        if (ControllerManager.GetBButtonFromPlayer(GetComponent<MoveTo>().m_PlayerID))
        {
            GetComponent<AudioSource>().PlayOneShot(randomAudiosources[Random.Range(0, randomAudiosources.Length)]);
        }
    }
}
