using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DB23_Countdown : MonoBehaviour
{
    [SerializeField]
    float startTime;
    float currentTime;
    bool timerStarted = false;

    [SerializeField]
    TMP_Text timerText;

    void Start()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
        timerStarted = true;
    }

    void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                Debug.Log("You Lose...");
                timerStarted = false;
                currentTime = 0;
                //Player LOSE State
            }

            timerText.text = "Time Remaining: " + currentTime.ToString("f0");
        }
    }
}