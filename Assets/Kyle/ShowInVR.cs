using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInVR : MonoBehaviour
{
    [SerializeField]
   Dictionary<GameObject,int> objectsInView = new Dictionary<GameObject, int>();
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("N: " + other.gameObject.name);
        if (other.gameObject.layer != LayerMask.NameToLayer("Both") && other.gameObject.layer != LayerMask.NameToLayer("Default") && other.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            GameObject localOther = other.gameObject;
            objectsInView.Add(localOther, localOther.layer);
            localOther.layer = LayerMask.NameToLayer("Both");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("E: " + other.gameObject.name);
        if(objectsInView.ContainsKey(other.gameObject))
        {
            other.gameObject.layer = objectsInView[other.gameObject];
            objectsInView.Remove(other.gameObject);

        }
    }
}
