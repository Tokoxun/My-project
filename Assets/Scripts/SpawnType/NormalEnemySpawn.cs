using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemySpawn : MonoBehaviour
{
    public float spawnTime = 5f;
    //The amount of time between each spawn
    public float spawnDelay = 3f;
    //The amount of time before spawning starts
    public GameObject[] enemies;
    //Array of enemy prefabs
    private int EnemyIndex = 0;

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        if(EnemyIndex == enemies.Length)
        {
            Destroy(gameObject);
        }
        else
        {
            Instantiate(enemies[EnemyIndex], transform.position, transform.rotation);
            EnemyIndex += 1;
        } 
    }
}
