using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NUnit.Framework;

public class ScoreManager : MonoBehaviour
{
    public List<CheckJoints> ObjectsWithJoints;
    public TextMeshProUGUI ScoreText;

    void Start()
    {
        UpdateScore();
        // When timer is off, and the simulation is completed/simulation continues this will calculate the score
    }

    void Update()
    {
        
    }

    public void UpdateScore()
    {
        int objectCount = ObjectsWithJoints.Count;
        int successfullObjectCount = 2;

        ScoreText.text = successfullObjectCount + " / " + objectCount;
    }
}
