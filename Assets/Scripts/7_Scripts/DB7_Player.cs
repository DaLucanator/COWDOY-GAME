using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_Player : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private bool thrust;
    private bool reverse;
    private float turnDirection;

    public DB7_Bullet bulletPrefab;
    public float moveSpeed;
    public float turnSpeed;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        thrust = (Input.GetKey(KeyCode.W));
        reverse = (Input.GetKey(KeyCode.S));

        if (Input.GetKey(KeyCode.A))
        {
            turnDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
            turnDirection = -1f;
        else
        {
            turnDirection = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void FixedUpdate()
    {
        if (thrust)
        {
            rigidbody.AddForce(this.transform.up * this.moveSpeed);
        }
        if (reverse)
        {
            rigidbody.AddForce(this.transform.up * this.moveSpeed * -1f);
        }
        if (turnDirection != 0f)
        {
            rigidbody.AddTorque(turnDirection * turnSpeed);
        }
    }

    private void Shoot()
    {
        DB7_Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hostile")
        {
            //Player Loss State
            print("You Lose...");
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = 0f;
            this.gameObject.SetActive(false);
        }
    }
}