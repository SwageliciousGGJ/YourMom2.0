using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionBase : MonoBehaviour
{
    [SerializeField]
    enum E_ArmHeight { LOW,MIDDLE,HIGH};
    [SerializeField]
    E_ArmHeight armHeight;
    [SerializeField]
    bool thrust;
    [SerializeField]
    string instult;

}
