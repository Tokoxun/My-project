using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurviveEnemySpawnManager : MonoBehaviour
{
    public float spawnTime = 2f;
    //The amount of time between each spawn
    public float spawnDelay = 1f;
    //The amount of time before spawning starts
    public GameObject[] enemies;
    //Array of enemy prefabs
    private float surviveTimer = 0;
    private float TimeOut = 60f;
    private float spawnTimer;
    private Transform movingPoints;
    

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
        spawnTimer += Time.deltaTime;
        if(surviveTimer >= TimeOut)
        {
            Destroy(gameObject);
        }
        if(spawnTimer >= spawnTime)
        {
            GameObject points = GameObject.Find("SpawnPoints");
            int PointToSpawn = Random.Range(0, 3);
            movingPoints = points.transform.GetChild(PointToSpawn);
            transform.position = movingPoints.transform.position;
            spawnTimer = 0;
        }
    }
}
