using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapRotater : MonoBehaviour
{
    private string sceneName;
    public CanvasGroup dialogBox;
    public Text TotalEnemy;
    public Text EnemyLeft;
    public float EnemyCount;
    private float enemyDied;
    public CanvasGroup EnemyCounter;
    public Text Timer;
    public CanvasGroup TimerImage;
    private float TimeLeft;
    public Animator FadeInOut;
    public GameObject PortalType;
    public string[] scenes;

    void Start()
    {
        TotalEnemy.text = EnemyCount.ToString();
        TimeLeft = 60;
        EnemyCount = 0;
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(col.GetComponent<Collider2D>().CompareTag("enemy"))
    //     {
    //         EnemyCount += 1;
    //         enemyDied = 0;
    //     }
    // }

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
        if(PortalType.GetComponent<NormalEnemySpawn>() != null)
        {
            EnemyCounter.alpha = 1;
            TimerImage.alpha = 0;
            EnemyLeft.text = enemyDied.ToString();
        }
        if(PortalType.GetComponent<SurviveEnemySpawnManager>() != null)
        {
            TimeLeft -= Time.deltaTime;
            Timer.text = TimeLeft.ToString();
            if(TimeLeft > 0)
            {
                Timer.text = TimeLeft.ToString();
            }
            else if(TimeLeft < 0)
            {
                Timer.text = "Portal Closing";
            }
            TimerImage.alpha = 1;
            EnemyCounter.alpha = 0; 
        }
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