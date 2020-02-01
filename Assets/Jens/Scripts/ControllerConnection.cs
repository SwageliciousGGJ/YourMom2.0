using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerConnection : MonoBehaviour
{
    public GameObject m_PlayerPrefab;
    public Transform[] m_SpawnPlaces;

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
            obj = Instantiate(m_PlayerPrefab, m_SpawnPlaces[i].transform.position, Quaternion.identity);

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
