using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckJoints : MonoBehaviour
{
    public JointObject[] joints;

    private int successfullCount;
    private float successRatio;

    private void Start()
    {
    }

    public void CheckJoint()
    {
        for (int i = 0; i < joints.Length; i++)
        {
            if (joints[i].jointSuccessful)
            {
                successfullCount++;
            }
        }

    }
}
