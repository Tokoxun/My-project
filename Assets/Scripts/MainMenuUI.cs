using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public string[] scenes;
    private string sceneName;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void loadScene()
    {
        sceneName = scenes[Random.Range(0, scenes.Length)];
        SceneManager.LoadScene(sceneName);
    }

}
