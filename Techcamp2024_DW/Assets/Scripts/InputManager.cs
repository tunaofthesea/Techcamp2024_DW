using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    public Camera cam;
    public LayerMask clickableLayer;

    private IClickable previousObject;

    public bool disable;

    public static InputManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(disable)
        {
            return;
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, Mathf.Infinity, clickableLayer))
        {
            if (previousObject != null)
            {
                previousObject.OffPointer();
                previousObject = null;
            }
            return;
        }

        IClickable triggeredObject = hit.collider.gameObject.GetComponent<IClickable>();

        if (previousObject != null && previousObject != triggeredObject)
        {
            previousObject.OffPointer();
            previousObject = null;
        }

        if (triggeredObject != null)
        {
            triggeredObject.OnPointer();
            previousObject = triggeredObject;

            if (Input.GetMouseButtonDown(0))
            {
                triggeredObject.OnClick();
            }
        }
    }
}

