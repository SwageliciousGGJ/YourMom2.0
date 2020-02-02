using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
#if UNITY_EDITOR
   [MenuItem("GameObject/UI Game/LinearProgressBar")]
    public static void AddLinearProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("GameObject/UI Game/LinearProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

    [MenuItem("GameObject/UI Game/RadialProgressBar")]
    public static void AddRadialProgressBar()
    {
        GameObject obj = Instantiate(Resources.Load<GameObject>("GameObject/UI Game/RadialProgressBar"));
        obj.transform.SetParent(Selection.activeGameObject.transform, false);
    }

#endif

    public int minimum;
    public int maximum;
    public int current;
    public Image mask;
    public Image fill;
    public Text progressText;
    public Color color;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
    }

    void GetCurrentFill()
    {
        float fillAmount = FaithController.m_Faith / 100;
        mask.fillAmount = fillAmount;
        fill.color = color;
    }

}
