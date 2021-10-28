using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DB23_Circuit : MonoBehaviour
{

    public UnityEvent RegisterCircuit;
    public UnityEvent DeregisterCircuit;

    // Start is called before the first frame update
    void Start()
    {
        RegisterCircuit.Invoke();
    }

    void OnDestroy()
    {
        DeregisterCircuit.Invoke();
    }
}