using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicroGameData : MonoBehaviour
{
    [SerializeField]
    float startTime;
    [SerializeField]
    bool isWinTimer;
    [SerializeField]
    string microGameName;
    [SerializeField]
    string microGameInstruction;

    private void Start()
    {
        GameController.current.MicroGameStart(startTime, isWinTimer, microGameName, microGameInstruction);
    }

}
