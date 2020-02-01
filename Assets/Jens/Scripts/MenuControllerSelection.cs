using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Valve.VR;

public class MenuControllerSelection : MonoBehaviour {

    [Header("Helper text")]
    public GameObject m_ContinueText;

    [Header("Joysticks images")]
    public Image[] m_JoysticksImages;
    private int m_ControllerCount;
    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        string[] joysticks = Input.GetJoystickNames();
        int count = 0;
        for (int i = 0; i < joysticks.Length; i++) {
            if (joysticks[i].Contains("Xbox")) {
                count++;
            }
        }
        m_ControllerCount = count;

        if (m_ControllerCount > 0) {
            m_ContinueText.SetActive(true);
        }
        else {
            m_ContinueText.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Space) && m_ControllerCount > 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void FixedUpdate() {
        string[] joysticks = Input.GetJoystickNames();

        int count = 0;
        for (int i = 0; i < joysticks.Length; i++) {
            if (joysticks[i].Contains("Xbox")) {
                count++;
            }
        }
        m_ControllerCount = count;

        for (int i = 0; i < 3; i++) {
            if (i < count) {
                m_JoysticksImages[i].GetComponent<Image>().color = new Color(m_JoysticksImages[i].GetComponent<Image>().color.r,
                m_JoysticksImages[i].GetComponent<Image>().color.g,
                m_JoysticksImages[i].GetComponent<Image>().color.b,
                1);
            }
            else {
                m_JoysticksImages[i].GetComponent<Image>().color = new Color(m_JoysticksImages[i].GetComponent<Image>().color.r,
                m_JoysticksImages[i].GetComponent<Image>().color.g,
                m_JoysticksImages[i].GetComponent<Image>().color.b,
                0.27f);
            }
        }
    }
}
