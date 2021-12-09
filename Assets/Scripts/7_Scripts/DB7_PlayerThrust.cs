using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_PlayerThrust : MonoBehaviour
{
    //this is Dan's work but Luc split it into 2 scripts for sprites to work as intended

    private bool thrust;
    private bool reverse;
    public AudioManager audioManager;
    public Rigidbody2D rigidbody;
    public float moveSpeed = 2;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrust = (Input.GetKey(KeyCode.W));
        reverse = (Input.GetKey(KeyCode.S));
    }

    void FixedUpdate()
    {
        if (thrust)
        {
            rigidbody.AddForce(this.transform.up * this.moveSpeed);
        }
        if (reverse)
        {
            rigidbody.AddForce(this.transform.up * this.moveSpeed * -1f);
        }

    }

    bool gamelose = true;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            if (gamelose == true)
            {
                //Player Loss State
                audioManager.PlayAuGameFail();
                print("You Lose...");
                gamelose = false;
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = 0f;
                this.gameObject.SetActive(false);
                GameController.current.ReturnToMain(false);
            }
        }
    }
}
