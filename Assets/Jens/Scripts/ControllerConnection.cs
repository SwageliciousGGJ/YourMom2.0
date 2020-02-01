using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerConnection : MonoBehaviour
{
    public GameObject m_PlayerPrefab;
    void Start()
    {
        string[] joysticks = Input.GetJoystickNames();

        int controllers = 0;
        for (int i = 0; i < joysticks.Length; i++)
        {
            if (joysticks[i].Contains("Xbox"))
            {
                controllers++;
            }
        }

        for (int i = 0; i < controllers; i++)
        {
            GameObject obj;
            if (controllers > 1)
            {
                if (i == 0)
                {
                    obj = Instantiate(m_PlayerPrefab, Vector3.zero, Quaternion.identity);
                }
                else
                {
                    obj = Instantiate(m_PlayerPrefab, new Vector3(50, 0, 0), Quaternion.identity);
                }
            }
            else
            {
                obj = Instantiate(m_PlayerPrefab, Vector3.zero, Quaternion.identity);
            }

            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            obj.GetComponent<MoveTo>().m_PlayerID = i;

            if (controllers > 1)
            {
                if (i == 0)
                {
                    obj.GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 1);
                }
                else
                {
                    obj.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
                }
            }
        }
    }
}
