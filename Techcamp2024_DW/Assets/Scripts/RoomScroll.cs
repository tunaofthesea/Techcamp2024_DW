using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScroll : MonoBehaviour
{
    public GameObject[] Room;
    public int roomIndex = 0;

    public delegate void RoomChanged();
    public RoomChanged roomChanged;

    // Start is called before the first frame update
    void Start()
    {
       /* foreach (var room in Room)
        {
            room.transform.Find("CCTV").gameObject.SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && roomIndex < Room.Length - 1)
        {
            roomChanged?.Invoke();
            roomIndex++;
            foreach (var room in Room)
            {                
                float conveyorPos = room.transform.position.x;
                conveyorPos -= 20;
                room.transform.position = new Vector3(conveyorPos, room.transform.position.y, room.transform.position.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && roomIndex > 0)
        {
            roomChanged?.Invoke();
            roomIndex--;
            foreach (var room in Room)
            {     
                float conveyorPos = room.transform.position.x;
                conveyorPos += 20;
                room.transform.position = new Vector3(conveyorPos, room.transform.position.y, room.transform.position.z);
            }
        }
    }
    void DisableCams()
    {
        foreach (var room in Room) 
        {
            room.GetComponentInChildren<Camera>().enabled = false; 
        }
    }
}
