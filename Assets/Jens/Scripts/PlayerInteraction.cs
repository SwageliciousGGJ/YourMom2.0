using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [Header("UI Interaction")]
    public GameObject m_Canvas;
    public GameObject m_InteractableImage;
    public Image m_InteractableImageFill;
    public GameObject m_PointScoreUIPrefab;
    public Image m_FaithImageFill;
    public Text m_FaithImageFillText;
    public TextMeshProUGUI m_ScoreText;

    private GameObject m_InRangeTemple;
    private bool m_CanInteract = false;

    public bool m_IsDestroying = false;
    private float m_DestroyCounter = 0;

    void Start() {
        m_InteractableImage.SetActive(false);
    }

    void Update()
    {
        m_FaithImageFillText.text = FaithController.m_Faith.ToString() + " / " + FaithController.m_MaxFaith.ToString();
        m_FaithImageFill.fillAmount = (float)FaithController.m_Faith / (float)FaithController.m_MaxFaith;
        m_ScoreText.text = "Your score: " + GetComponent<SinglePlayerStats>().m_Points.ToString();

        if (ControllerManager.GetAButtonFromPlayer(GetComponent<MoveTo>().m_PlayerID)) {
            if (m_CanInteract) {
                Interact();
            }
        }

        if (ControllerManager.GetAButtonDownFromPlayer(GetComponent<MoveTo>().m_PlayerID)) {
            GetComponent<Animator>().SetBool("bounce", true);
        }
        else {
            GetComponent<Animator>().SetBool("bounce", false);
        }

        if (m_IsDestroying) {
            m_DestroyCounter = m_DestroyCounter + Time.deltaTime;
            m_InteractableImageFill.fillAmount = m_DestroyCounter / m_InRangeTemple.GetComponent<Temple>().m_TimeToDestroy;
            if (ControllerManager.GetAButtonUpFromPlayer(GetComponent<MoveTo>().m_PlayerID)) {
                m_IsDestroying = false;
                m_CanInteract = true;
            }

            if (m_DestroyCounter >= m_InRangeTemple.GetComponent<Temple>().m_TimeToDestroy) {
                m_InRangeTemple.GetComponent<Temple>().Attack(this.gameObject);
                m_IsDestroying = false;
                m_CanInteract = true;
                StartCoroutine(SpawnPointUIPrefab());
            }
        }
    }

    public void Interact() {
        m_DestroyCounter = 0;
        m_CanInteract = false;
        m_IsDestroying = true;
    }

    public void OnCanInteractWithObject(GameObject a_Object) {
        m_InRangeTemple = a_Object;
        m_InteractableImage.SetActive(true);
        m_InteractableImageFill.fillAmount = 0;
        m_CanInteract = true;
    }

    public void OnDisableInteractWithObject(GameObject a_Object) {
        m_InRangeTemple = null;
        m_InteractableImage.SetActive(false);
        m_CanInteract = false;
    }

    public void Damage() {
        int health = GetComponent<SinglePlayerStats>().m_Lifes;

        if (health <= 0) {
            Debug.Log("Dead");
        }

        Transform[] SpawnPlaces = FindObjectOfType<ControllerConnection>().m_SpawnPlaces;

        Transform spawn = SpawnPlaces[Random.Range(0, SpawnPlaces.Length)];

        gameObject.transform.position = spawn.position;
    }

    IEnumerator SpawnPointUIPrefab() {
        GameObject obj = Instantiate(m_PointScoreUIPrefab, m_Canvas.transform);
        obj.GetComponent<TextMeshPro>().text = "+ " + m_InRangeTemple.GetComponent<Temple>().m_ReceivedDestroyCurrency;
        obj.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1);
        Destroy(obj);
    }
}
