using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB10SnakeAlt : MonoBehaviour
{
    public GameObject train;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameController.current.ReturnToMain(true);
        }
    }
}