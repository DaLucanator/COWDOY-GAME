using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB7_EnemySpawn : MonoBehaviour
{
    public DB7_Enemy enemyPrefab;
    public int spawnAmount = 1;
    public float spawnRate = 2f;
    public float spawnSpread = 10f;
    public float spawnVariance = 15f;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnSpread;
            Vector3 spawnPoint = this.transform.position + spawnDirection;
            float variance = Random.Range(-this.spawnVariance, this.spawnVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            DB7_Enemy enemy = Instantiate(this.enemyPrefab, spawnPoint, rotation);
            enemy.size = Random.Range(enemy.minSize, enemy.maxSize);
            enemy.SetTrajectory(rotation * -spawnDirection);
        }
    }
}