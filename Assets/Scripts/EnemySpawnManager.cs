// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EnemySpawnManager : MonoBehaviour
// {
//     public float spawnTime = 5f;
//     //The amount of time between each spawn
//     public float spawnDelay = 3f;
//     //The amount of time before spawning starts
//     public Gameobject[] enemies;
//     //Array of enemy prefabs
//     // Start is called before the first frame update
//     void Start()
//     {
//         InvokeRepeating("Spawn", spawnDelay, spawnTime);
//     }

//     void Spawn()
//     {
//         //Instantiate a random enemy
//         int enemyIndex = Random.Range(0, enemies.Length);
//         Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
