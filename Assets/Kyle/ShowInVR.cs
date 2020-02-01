using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInVR : MonoBehaviour
{
    [SerializeField]
   Dictionary<GameObject,int> objectsInView = new Dictionary<GameObject, int>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != LayerMask.NameToLayer("Both") && other.gameObject.layer != LayerMask.NameToLayer("Default") && other.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            GameObject localOther = other.gameObject;
            objectsInView.Add(localOther, localOther.layer);
            localOther.layer = LayerMask.NameToLayer("Both");
            Transform parent = null;
            if(localOther.transform.childCount > 0)
            {
                parent = localOther.transform;
                while(parent!=null)
                {
                    foreach (Transform t in parent)
                    {
                        parent = null;
                        if(t!=parent)
                        {
                            t.gameObject.layer = LayerMask.NameToLayer("Both");
                            if(t.childCount > 0)
                            {
                                parent = t;
                            }
                        }
                    }

                }
            }
         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(objectsInView.ContainsKey(other.gameObject))
        {
            int layer = objectsInView[other.gameObject];
            other.gameObject.layer = layer;
            Transform parent = null;
            if (other.transform.childCount > 0)
            {
                parent = other.transform;
                while (parent != null)
                {
                    foreach (Transform t in parent)
                    {
                        parent = null;
                        if (t != parent)
                        {
                            t.gameObject.layer = layer;
                            if (t.childCount > 0)
                            {
                                parent = t;
                            }
                        }
                    }

                }
            }
            objectsInView.Remove(other.gameObject);

        }
    }
}
