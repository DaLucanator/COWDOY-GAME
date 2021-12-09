using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_Manager : MonoBehaviour
{
    public ParticleSystem explosion;
    public AudioManager audioManager;

    public void EnemyDestroyed(DB7_Enemy enemy)
    {
        audioManager.PlayAuGameShootHit();
        this.explosion.transform.position = enemy.transform.position;
        this.explosion.Play();
    }
}