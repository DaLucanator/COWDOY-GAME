using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB23_CollectWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            print("You Win!");
            Destroy(gameObject);
            //Go to Game Win Scene;
        }
    }
}