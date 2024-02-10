using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointObject : InteractionObject
{
    public JointTag jointTag;
    public bool jointSuccessful;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnClick()
    {
        base.OnClick();
        Inventory.instance.CheckCurrentSlot(this);
    }
}

public enum JointTag
{
    Plate,
    Clip,
    GlassFilm,
}

