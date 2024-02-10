using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public Transform ControlPanelRoom;

    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.transform.position = ControlPanelRoom.transform.position;
        }
    }
}
