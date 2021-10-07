using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB28_Player : MonoBehaviour
{
    public int startHp;
    public int hp;
    public float bulletCooldown;
    float bulletTimer;

    void Start()
    {
        hp = startHp;
    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer -= Time.deltaTime;

        if (hp == 0)
        {
            print("You Lose...");
            Destroy(gameObject);
            //Go to Game Over Scene;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hostile" && bulletTimer <= 0)
        {
            hp -= 1;
            print(hp);
            bulletTimer = bulletCooldown;
            //Sound effect "Player Hurt"//
        }
    }
}
