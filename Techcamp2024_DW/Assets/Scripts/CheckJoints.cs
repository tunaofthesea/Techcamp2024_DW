using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJoints : MonoBehaviour
{
    public List<JointObject> joints = new List<JointObject>();

    private int successfullCount;
    private float successRatio;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log(name + " " + CheckJointRatio());
        }
    }

    public float CheckJointRatio()
    {
        successfullCount = 0;

        for (int i = 0; i < joints.Count; i++)
        {
            if (joints[i].jointSuccessful)
            {
                successfullCount++;
            }
        }

        successRatio = (float)successfullCount / (float)joints.Count;

        return successRatio;
    }
}
