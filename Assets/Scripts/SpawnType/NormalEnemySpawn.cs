using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemySpawn : MonoBehaviour
{
    public float spawnTime = 2f;
    //The amount of time between each spawn
    public float spawnDelay = 1f;
    //The amount of time before spawning starts
    public GameObject[] enemies;
    //Array of enemy prefabs
    private int EnemyIndex = 0;
    private Transform movingPoints;
    private float spawnTimer;

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

    void Update()
    {
        spawnTimer += Time.deltaTime;
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
