using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB13_CircuitKillcheck : MonoBehaviour
{
    public int ActiveCircuits = 0;

    public void RegisterCircuit()
    {
        ActiveCircuits++;
    }

    public void DeregisterCircuit()
    {
        ActiveCircuits--;

        if (ActiveCircuits <= 0)
        {
            Debug.Log("You Win!");
            GameController.current.ReturnToMain(true);
        }
    }
}