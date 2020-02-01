using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaithMeter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float maxFaith = 500;
    [SerializeField]
    float fillAmount;
    [SerializeField]
    Image uiImage;
    void Start()
    {
        uiImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = FaithController.m_Faith / maxFaith;
        uiImage.fillAmount = fillAmount;
    }
}
