using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB13_MouseScript : MonoBehaviour
{
    void Update()
    {
        this.transform.position = Input.mousePosition;
    }
}