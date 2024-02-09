using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    private GameObject holdObject;
    public static ObjectHolder instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject CheckObject()
    {
        return holdObject;
    }

    public void HoldObject(GameObject go)
    {
        if(holdObject != null)
        {
            if(holdObject == go)
            {
                holdObject.transform.SetParent(null);
                holdObject = null;
                return;
            }

            holdObject.transform.SetParent(null);
            holdObject.transform.position = go.transform.position;

            holdObject = go;
            holdObject.transform.position = transform.position + transform.forward * 0.5f;
            holdObject.transform.SetParent(transform);
            return;
        }

        holdObject = go;
        holdObject.transform.position = transform.position + transform.forward * 0.5f;
        holdObject.transform.SetParent(transform);
    }
}
