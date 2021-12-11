using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB23_PlayerMovement : MonoBehaviour
{
    public AudioManager audioManager;

    public float speed = 10.0f;
    public Rigidbody2D rb;
    public Vector2 movement;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hostile")
        {
            audioManager.PlayAuGameFail();
            print("You Lose...");
            Destroy(gameObject);
            GameController.current.ReturnToMain(false);
            //Go to Game Over Scene;
        }
    }
}