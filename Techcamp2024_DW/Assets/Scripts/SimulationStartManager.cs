using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationStartManager : MonoBehaviour
{
    public List<CheckJoints> ObjectsWithJoints;
    public List<Rigidbody> gravityBodies;
    public GameObject CurrentEarthQuakeFloor;
    public static SimulationStartManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void CheckObjects()
    {
        for (int i = 0; i < ObjectsWithJoints.Count; i++)
        {
            if(ObjectsWithJoints[i].CheckJointRatio() < 0.5f)
            {
                ObjectsWithJoints[i].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                ObjectsWithJoints[i].GetComponent<Rigidbody>().useGravity = true;
                ObjectsWithJoints[i].GetComponent<Rigidbody>().isKinematic = false;
                ObjectsWithJoints[i].GetComponent<Break>().safe = false;
            }

            else
            {
                ObjectsWithJoints[i].transform.parent.SetParent(CurrentEarthQuakeFloor.transform);  // When room changes, change the floor as well
            }
        }

        for (int i = 0; i < gravityBodies.Count; i++)
        {
            gravityBodies[i].useGravity = true;
        }
    }
}
