using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwap : MonoBehaviour
{
    RoomScroll roomScroll;
    GameObject activeRoom;

    private bool peeping;
    // Start is called before the first frame update
    void Start()
    {
        roomScroll = gameObject.GetComponent<RoomScroll>();
        roomScroll.roomChanged += UpdateCam;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) &! peeping) 
        {
            peeping = true;
            //UpdateCam();
            roomScroll = gameObject.GetComponent<RoomScroll>();
            activeRoom = (GameObject)roomScroll.Room.GetValue(roomScroll.roomIndex);
            activeRoom.transform.GetComponentInChildren<Camera>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && activeRoom != null) 
        {
            peeping = false;
            activeRoom.transform.GetComponentInChildren<Camera>().enabled = false;
        }
    }
    public void UpdateCam()
    {
        Debug.Log("CHANGED!");
        roomScroll = gameObject.GetComponent<RoomScroll>();
        if (activeRoom != null)
        {
            activeRoom.transform.GetComponentInChildren<Camera>().enabled = false;
        }

        roomScroll = gameObject.GetComponent<RoomScroll>();

        activeRoom = (GameObject)roomScroll.Room.GetValue(roomScroll.roomIndex);

        if (peeping)
        {
            activeRoom.transform.GetComponentInChildren<Camera>().enabled = true;
        }
        
    }
}
