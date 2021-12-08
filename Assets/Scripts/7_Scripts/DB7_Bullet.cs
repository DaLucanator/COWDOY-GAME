using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_Bullet : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float lifetime = 10f;
    public float speed = 300f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Project(Vector2 direction)
    {
        rigidbody.AddForce(direction * this.speed);
        Destroy(this.gameObject, this.lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}