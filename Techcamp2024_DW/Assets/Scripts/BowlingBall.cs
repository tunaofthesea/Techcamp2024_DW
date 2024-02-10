using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : InteractionObject, IHoldable
{
    public bool isHeavy;
    public float heigthLimit;

    public bool canHarm;



    protected override void Start()
    {
        base.Start();
        if(isHeavy)
        {
            canHarm = CheckHeight();
        }
    }

    public void OnHold()
    {
        
    }

    private bool CheckHeight()
    {
        if(transform.position.y > heigthLimit)
        {
            return true;
        }
        return false;
    }

}
