using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour, IPlaceable
{

    public void Place()
    {
        Debug.Log("a");
    }

    public bool CanBePlaced()
    {
        return true;
    }

}
