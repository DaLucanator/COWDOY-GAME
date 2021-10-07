using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB28_Bullet : MonoBehaviour
{
    public Vector3 velocity;
    public float speed;
    public float rotation;

    //public float lifeTime;
    //float timer; //How long the bullet lasts until it is destroyed//

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);

        //Use the following to give bullets an active time limit
        //timer -= Time.deltaTime;
        //if (timer <= 0) gameObject.SetActive(false);
    }

    //public void ResetTimer()
    //{
    //    timer = lifeTime;
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Buffer")
        {
            Destroy(gameObject);
        }

    }
}
