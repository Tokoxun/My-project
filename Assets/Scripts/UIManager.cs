using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    GameObject[] pauseObjects;
    public string[] scenes;
    private string sceneName;
    private GameObject deathScreen;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
        deathScreen = GameObject.Find("DeathScreen");
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		deathScreen.SetActive(false);
		hidePaused();
	}

	// Update is called once per frame
	void Update () 
    {
		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} 
            else if (Time.timeScale == 0)
            {
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} 
            else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects)
        {
			g.SetActive(true);
		}
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects)
        {
			g.SetActive(false);
		}
	}

	//loads inputted level
	// public void LoadLevel(string level)
    // {
	// 	SceneManager.LoadScene(level);
	// }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void loadScene()
    {
		Difficulty removeDiff = FindObjectOfType<Difficulty>();
		removeDiff.diff = 1.0f;
        sceneName = scenes[Random.Range(0, scenes.Length)];
        SceneManager.LoadScene(sceneName);
    }

    public void PlayerDied()
    {
        Time.timeScale = 0;
        deathScreen.SetActive(true);
    }
}
