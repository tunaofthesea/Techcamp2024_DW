using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    private int currentSlotIndex = 0;

    private GameObject previousSlot;

    private void Start()
    {
        //MoveSelector(0);
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            MoveSelector(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            MoveSelector(-1);
        }
    }

    void MoveSelector(int direction)
    {
        currentSlotIndex += direction;

        if (currentSlotIndex >= slots.Count)
        {
            currentSlotIndex = 0;
        }
        else if (currentSlotIndex < 0)
        {
            currentSlotIndex = slots.Count - 1;
        }

        if(previousSlot != null)
        {
            previousSlot.transform.localScale = Vector3.one;
        }

        slots[currentSlotIndex].transform.localScale = Vector3.one * 1.35f;
        previousSlot = slots[currentSlotIndex];

    }
}
