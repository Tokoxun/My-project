using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveEnemySpawnManager : MonoBehaviour
{
    public float spawnTime = 4f;
    //The amount of time between each spawn
    public float spawnDelay = 3f;
    //The amount of time before spawning starts
    public GameObject[] enemies;
    //Array of enemy prefabs
    private float surviveTimer = 0;
    private float TimeOut = 60f;
    private float spawnTimer;
    // public Transform movingPoints;
    // private Transform moving;
    

    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    void Spawn()
    {
        //Instantiate a random enemy
        int enemyIndex = Random.Range(0, enemies.Length);
        Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }

    void Update()
    {
        surviveTimer += Time.deltaTime;
        if(surviveTimer >= TimeOut)
        {
            Destroy(gameObject);
        }
    }
}
