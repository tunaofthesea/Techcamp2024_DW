using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public GameObject platePrefab;
    public GameObject clipPrefab;
    public GameObject filmPrefab;

    private int currentSlotIndex = 0;

    private GameObject previousSlot;
    private GameObject currentSlot;
    private GameObject objectToInstantiate;

    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

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
        currentSlot = slots[currentSlotIndex];
        previousSlot = slots[currentSlotIndex];
    }

    public void CheckCurrentSlot(JointObject jointObject)
    {
        if(currentSlot == null)
        {
            return;
        }

        if(jointObject.jointTag.ToString() != currentSlot.tag)
        {
            //Play wrong placement animation
            return;
        }

        switch(jointObject.jointTag)
        {
            case JointTag.Plate:
                objectToInstantiate = platePrefab;
                break;

            case JointTag.Clip:
                objectToInstantiate = clipPrefab;
                break;

            case JointTag.GlassFilm:
                objectToInstantiate = filmPrefab;
                break;
        }

        GameObject go = Instantiate(objectToInstantiate, jointObject.transform.position, Quaternion.identity);
        go.transform.rotation = jointObject.gameObject.transform.localRotation;
        go.transform.SetParent(jointObject.transform.parent);
        go.GetComponent<Animator>().enabled = true;

        jointObject.jointSuccessful = true;
        jointObject.gameObject.SetActive(false);
    }

}

