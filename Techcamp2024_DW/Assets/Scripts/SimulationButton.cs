using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationButton : InteractionObject
{
    public Animator anim;

    protected override void Start()
    {
        
        base.Start();
    }
    public override void OnClick()
    {
        base.OnClick();
        anim.SetBool("IsOpen", true);
        UIManager uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        uiManager.StartTimer();
    }
}
