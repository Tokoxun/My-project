using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapRotater : MonoBehaviour
{
    private string sceneName;
    public CanvasGroup dialogBox;
    public float EnemyCount;
    private float enemyDied;
    public Text Timer;
    public CanvasGroup TimerImage;
    private float TimeLeft;
    public Animator FadeInOut;
    public GameObject PortalType;
    public string[] scenes;
    public float multiplier = 0.1f;
    public UnityAdDisplay UnityAd;
    // public GameObject enem;

    void Start()
    {
        UnityAd.LoadAd();
        UnityAd.ShowAd();
        TimeLeft = 60;
        EnemyCount = 0;
        enemyDied = 0;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<Collider2D>().CompareTag("enemy"))
        {
            EnemyCount += 1;
        }
    }

    public void EnemyKilled()
    {
        enemyDied += 1;
    }

    void Update()
    {
        // DetectionZone detect = enem.GetComponent<DetectionZone>();
        // Debug.Log(detect.playerNotDetected);
        if(PortalType.GetComponent<NormalEnemySpawn>() != null)
        {
            if(enemyDied == EnemyCount)
            {
                StartCoroutine(LoadNextScene());
            }
            TimerImage.alpha = 0;
        }
        if(PortalType.GetComponent<SurviveEnemySpawnManager>() != null)
        {
            TimeLeft -= Time.deltaTime;
            Timer.text = TimeLeft.ToString();
            if(TimeLeft < 0 && enemyDied == EnemyCount)
            {
                StartCoroutine(LoadNextScene());
            }
            if(TimeLeft > 0)
            {
                Timer.text = TimeLeft.ToString();
            }
            if(TimeLeft < 0)
            {
                Timer.text = "Portal Closing";
            }
            TimerImage.alpha = 1;
        }
    }

    IEnumerator LoadNextScene()
    {
        sceneName = scenes[Random.Range(0, scenes.Length)];
        EnemyCount = 0;
        enemyDied = 0;
        dialogBox.alpha = 1;
        dialogBox.blocksRaycasts = true;
        FadeInOut.SetBool("Start", true);
        yield return new WaitForSeconds(2f);
        Difficulty addDiff = FindObjectOfType<Difficulty>();
        addDiff.diff = addDiff.diff + multiplier;
        SceneManager.LoadScene(sceneName);
        // dialogBox.alpha = 0;
        // dialogBox.blocksRaycasts = false;
    }
}