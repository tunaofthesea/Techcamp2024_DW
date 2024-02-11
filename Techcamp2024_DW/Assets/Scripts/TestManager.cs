using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Transform ControlPanelRoom;
    private Vector3 initialPos;

    public GameObject player;
    public int count;

    private void Start()
    {
        initialPos = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            count++;
            if(count % 2 == 0)
            {
                player.transform.position = initialPos;
                count = 0;
                return;
            }
            player.transform.position = ControlPanelRoom.transform.position;
        }
    }
}
