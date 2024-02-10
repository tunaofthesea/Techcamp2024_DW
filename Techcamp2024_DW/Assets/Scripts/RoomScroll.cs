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
        if (Input.GetKeyDown(KeyCode.T) && roomIndex < Room.Length - 1)
        {
            roomChanged?.Invoke();
            roomIndex++;
            foreach (var room in Room)
            {
                StartCoroutine("StartLerpRight", room);
            }
        }
        if (Input.GetKeyDown(KeyCode.R) && roomIndex > 0)
        {
            roomChanged?.Invoke();
            roomIndex--;
            foreach (var room in Room)
            {
                StartCoroutine("StartLerpLeft", room);
            }
        }
    }
    IEnumerator StartLerpRight(GameObject x)
    {
        float conveyorPos = x.transform.position.x;
        while (true)
        {
            Vector3 endPos = new Vector3(conveyorPos - 20, x.transform.position.y, x.transform.position.z);
            x.transform.position = Vector3.Lerp(x.transform.position, endPos, 2f * Time.deltaTime);
            if (Vector3.Distance(x.transform.position, endPos) <= 0.1f)
            {
                transform.position = endPos;
                yield break;
            }
            yield return null;
        }
    }
    IEnumerator StartLerpLeft(GameObject x)
    {
        float conveyorPos = x.transform.position.x;
        while (true)
        {
            Vector3 endPos = new Vector3(conveyorPos + 20, x.transform.position.y, x.transform.position.z);
            x.transform.position = Vector3.Lerp(x.transform.position, endPos, 2f * Time.deltaTime);
            if (Vector3.Distance(x.transform.position, endPos) <= 0.1f)
            {
                transform.position = endPos;
                yield break;
            }
            yield return null;
        }
    }
}
 
