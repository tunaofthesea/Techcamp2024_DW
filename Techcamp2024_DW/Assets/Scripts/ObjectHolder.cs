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
        if(holdObject == null)
        {
            return null;
        }
        GameObject go = holdObject;
        holdObject = null;
        go.transform.SetParent(null);

        return go;
    }

    public void HoldObject(GameObject go)
    {
        if(holdObject != null)
        {
            if(holdObject == go)
            {
                holdObject.transform.SetParent(null);
                holdObject.GetComponent<Rigidbody>().useGravity = true;
                holdObject = null;
                return;
            }

            holdObject.transform.SetParent(null);
            holdObject.GetComponent<Rigidbody>().useGravity = true;
            holdObject.transform.position = go.transform.position;

            holdObject = go;
            holdObject.GetComponent<Rigidbody>().useGravity = false;
            holdObject.transform.position = transform.position + transform.forward * 0.5f;
            holdObject.transform.SetParent(transform);
            return;
        }

        holdObject = go;
        holdObject.GetComponent<Rigidbody>().useGravity = false;
        holdObject.transform.position = transform.position + transform.forward * 0.5f;
        holdObject.transform.SetParent(transform);
    }
}
