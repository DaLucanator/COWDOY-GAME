using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB23_CollectWin : MonoBehaviour
{
    bool gamewin = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gamewin == true)
            {
                print("You Win!");
                Destroy(gameObject);
                gamewin = false;
                GameController.current.ReturnToMain(true);
                //Go to Game Win Scene;
            }
        }
    }
}