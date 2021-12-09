using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_Player : MonoBehaviour
{
    private float turnDirection;
    public AudioManager audioManager;
    public DB7_Bullet bulletPrefab;
    public float turnSpeed;

    private void Update()
    {
        transform.Rotate(0, 0, -turnSpeed * Input.GetAxisRaw("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    private void Shoot()
    {
        audioManager.PlayAuGameShoot();
        DB7_Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
}