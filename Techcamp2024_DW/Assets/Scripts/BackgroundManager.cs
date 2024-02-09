using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject blackBG;
    public static BackgroundManager instance;

    private Animator backgroundAnimator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        blackBG = GameObject.Find("Black BG");

        if(blackBG!= null)
        {
            backgroundAnimator = blackBG.GetComponent<Animator>();
        }
    }

    public void BlackOut()
    {
        backgroundAnimator.Play("Black_BG_on");
    }

    public void BlackIn()
    {
        backgroundAnimator.Play("Black_BG_off");
    }
}
