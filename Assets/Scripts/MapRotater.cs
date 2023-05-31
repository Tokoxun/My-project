using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapRotater : MonoBehaviour
{
    public CanvasGroup dialogBox;
    public Text TotalEnemy;
    public Text EnemyLeft;
    private string sceneName;
    public string[] scenes;
    private float EnemyCount;
    private float enemyDied;
    public Animator FadeInOut;

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
            StartCoroutine(LoadNextScene());
        }
    }

    void Update()
    {
        EnemyLeft.text = enemyDied.ToString();
        TotalEnemy.text = EnemyCount.ToString();
    }

    IEnumerator LoadNextScene()
    {
        dialogBox.alpha = 1;
        dialogBox.blocksRaycasts = true;
        FadeInOut.SetBool("Start", true);
        yield return new WaitForSeconds(2f);
        sceneName = scenes[Random.Range(0, scenes.Length)];
        SceneManager.LoadScene(sceneName);
        dialogBox.alpha = 0;
        dialogBox.blocksRaycasts = false;
        enemyDied = 0;
    }
}