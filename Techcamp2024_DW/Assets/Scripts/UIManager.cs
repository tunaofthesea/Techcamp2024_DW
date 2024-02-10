using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public bool timeractive;
    public float countdown = 0f;
    public float countdownlimit = 0f;

    public RoomScroll roomScroll;
    EarthquakeSimulatorManager earthquake;

    GameObject floor;

    private void Start()
    {
        //roomScroll.roomChanged += GetQuakeFloor;
        //floor = (GameObject)roomScroll.Room.GetValue(roomScroll.roomIndex);
    }
    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartTimer();
        }

        if(timeractive)
        {
            countdown -= Time.deltaTime;
            UpdateTimer();
            UpdateTextColor();
            
            if(countdown <= 0f)
            {
                timeractive = false;
                countdown = 0f;
                timer.text = "00:00";

                floor = (GameObject)roomScroll.Room.GetValue(roomScroll.roomIndex);
                floor.gameObject.GetComponentInChildren<EarthquakeSimulatorManager>().enabled = true;
                floor.gameObject.GetComponentInChildren<EarthquakeSimulatorManager>().StartCoroutine("Intensify");
            }
        }
    }
    public void GetQuakeFloor()
    {
        if (floor != null)
            floor.gameObject.GetComponentInChildren<EarthquakeSimulatorManager>().enabled = false;
        floor = (GameObject)roomScroll.Room.GetValue(roomScroll.roomIndex);
    }

    public void StartTimer()
    {
        timeractive = true;
        countdown = countdownlimit;
    }

    public void UpdateTimer()
    {
        // Convert remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(countdown / 60);
        int seconds = Mathf.FloorToInt(countdown % 60);

        // Update UI text to display remaining time in minutes
        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void UpdateTextColor()
    {
        // Calculate normalized time value between 0 and 1
        float normalizedTime = countdown / countdownlimit; // Assuming 3 minutes

        // Interpolate color between startColor and endColor based on normalized time
        timer.color = Color.Lerp(Color.green, Color.red, 1 - normalizedTime);
    }
}
