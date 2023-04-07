using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapRotater : MonoBehaviour
{
    private string sceneName;
    public string[] scenes;
    private float EnemyCount;
    private float enemyDied;

    void Start()
    {
        EnemyCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Collider2D>().CompareTag("enemy"))
        {
            EnemyCount += 1;
            enemyDied = 0;
        }
    }

    public void EnemyKilled()
    {
        enemyDied += 1;
        Debug.Log(enemyDied);
        if(enemyDied == EnemyCount)
        {
            sceneName = scenes[Random.Range(0, scenes.Length)];
            SceneManager.LoadScene(sceneName);
        }
    }
}