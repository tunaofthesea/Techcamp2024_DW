using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isBroken;
    public bool safe;
    void Start()
    {
        
    }
    public void BreakObject()
    {
        if (isBroken || safe)
        {
            return;
        }
        isBroken = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        //GetComponent<BoxCollider>().enabled = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
