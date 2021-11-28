using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    float startTimeLocal;
    bool isWinTimerLocal = false;
    float currentTime;
    int displayTime;

    [SerializeField]
    GameObject timerTextObject;
    [SerializeField]
    TextMeshProUGUI timerText;

    [ReadOnly]
    public bool timerGo = false;

    public void Start()
    {
        timerTextObject.SetActive(false);
    }

    public void TimerStart(float startTime, bool isWinTimer)
    {
        startTimeLocal = startTime;
        timerTextObject.SetActive(true);
        isWinTimerLocal = isWinTimer;
        currentTime = startTimeLocal;
        timerGo = true;
    }

    public void TimerStop()
    {
        timerGo = false;
        timerTextObject.SetActive(false);
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
        if (displayTime >= 10) { timerText.text = "COUNTDOWN: " + displayTime.ToString(); }
        else { timerText.text = "COUNTDOWN: 0" + displayTime.ToString(); }
    }
}
