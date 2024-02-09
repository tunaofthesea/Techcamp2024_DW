using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour, IClickable
{
    private Outline outline;
    public Canvas objectCanvas;
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    public void OnPointer()
    {
        outline.enabled = true;
    }

    public void OffPointer()
    {
        outline.enabled = false;
    }

    public void OnClick()
    {

    }
}
