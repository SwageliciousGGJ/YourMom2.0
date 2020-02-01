using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaithController : MonoBehaviour
{
    public static int m_Faith;

    void Start()
    {
        m_Faith = 0;
        StartCoroutine(GetFaithFromTemples());
    }

    IEnumerator GetFaithFromTemples()
    {
        Temple[] temples = FindObjectsOfType<Temple>();

        for (int i = 0; i < temples.Length; i++)
        {
            m_Faith += temples[i].m_CurrencyOverTime;
        }
        Debug.Log(m_Faith);
        yield return new WaitForSeconds(1);
        StartCoroutine(GetFaithFromTemples());
    }
}
