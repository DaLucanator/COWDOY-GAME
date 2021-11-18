using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float startTimeLocal;
    bool isWinTimerLocal = false;
    public TextMeshProUGUI timerText;
    float currentTime;
    bool timerGo = false;
    int displayTime;

    public void TimerStart(float startTime, bool isWinTimer)
    {
        startTimeLocal = startTime;
        isWinTimerLocal = isWinTimer;
        currentTime = startTimeLocal;
        timerGo = true;
    }

    void Update()
    {
        if (timerGo)
        {
            currentTime -= Time.deltaTime;
            displayTime = Mathf.RoundToInt(currentTime);
            if (currentTime <= 0)
            {
                timerGo = false;
                currentTime = 0;
                GameController.current.ReturnToMain(isWinTimerLocal);
            }
        }
        if (displayTime >= 10) { timerText.text = "TIME REMAINING: " + displayTime.ToString(); }
        else { timerText.text = "TIME REMAINING: 0" + displayTime.ToString(); }
    }
}
