using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB28_WinCoin : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public float rotation;

    public float spinSpeed = 100f;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);
        this.transform.Rotate(Time.deltaTime * this.spinSpeed, 0f, 0f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            print("You Win!");
            Destroy(gameObject);
            //Go to Win Scene;
        }
        if (collision.tag == "Buffer")
        {
            print("You Lose...");
            Destroy(gameObject);
            //Go to Game Over Scene;
        }

    }
}
