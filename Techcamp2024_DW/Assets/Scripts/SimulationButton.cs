using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationButton : InteractionObject
{
    protected override void Start()
    {
        
        base.Start();
    }


    public override void OnClick()
    {
        base.OnClick();
        UIManager uiManager = GameObject.Find("GameManager").GetComponent<UIManager>();
        uiManager.StartTimer();
        SimulationStartManager.instance.CheckObjects();
    }
}
