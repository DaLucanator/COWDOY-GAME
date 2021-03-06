using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DB7_Countdown : MonoBehaviour
{
    [SerializeField]
    float startTime;
    float currentTime;
    bool timerStarted = false;
    bool gamewin = true;

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
                if (gamewin == true)
                {
                    Debug.Log("You Win!");
                    gamewin = false;
                    timerStarted = false;
                    currentTime = 0;
                    //Player WIN State
                    GameController.current.ReturnToMain(true);
                }
            }
            timerText.text = "Time Remaining: " + currentTime.ToString("f0");
        }
    }
}