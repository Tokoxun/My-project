using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject[] objectToSpawn;  // The prefab of the object you want to spawn

    private PolygonCollider2D spawnCollider;
    private float spawnCooldown = 4.5f;
    private float BuffSpawn = 0f;

    private void Start()
    {
        spawnCollider = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        BuffSpawn += Time.deltaTime;
        if(BuffSpawn >= spawnCooldown)
        {
            Vector3 spawnPoint = new Vector3(
            Random.Range(spawnCollider.bounds.min.x, spawnCollider.bounds.max.x),
            Random.Range(spawnCollider.bounds.min.y, spawnCollider.bounds.max.y),
            Random.Range(spawnCollider.bounds.min.z, spawnCollider.bounds.max.z)
            );

            int buffIndex = Random.Range(0, objectToSpawn.Length);
            Instantiate(objectToSpawn[buffIndex], spawnPoint, Quaternion.identity);
            BuffSpawn = 0;
        }
    }
}
