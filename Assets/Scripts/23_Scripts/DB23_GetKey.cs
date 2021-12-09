using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB23_GetKey : MonoBehaviour
{
    public AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            audioManager.PlayAuMenuAccept();
            Destroy(gameObject);
        }
    }
}