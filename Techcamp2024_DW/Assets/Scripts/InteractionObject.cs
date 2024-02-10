using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IClickable
{
    private Outline outline;
    public Canvas objectCanvas;
    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void OnPointer()
    {
        Debug.Log(name);
        outline.enabled = true;
    }

    public void OffPointer()
    {
        outline.enabled = false;
    }

    public virtual void OnClick()
    {

    }
}
