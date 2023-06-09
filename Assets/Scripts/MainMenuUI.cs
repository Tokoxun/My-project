using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public string[] scenes;
    private string sceneName;
    private GameObject instructionMenu;
	private GameObject exitInstruction;
    // Start is called before the first frame update
    void Start()
    {
        instructionMenu = GameObject.Find("controlImage");
        exitInstruction = GameObject.Find("Exit");
        instructionMenu.SetActive(false);
    }

    public void loadScene()
    {
        sceneName = scenes[Random.Range(0, scenes.Length)];
        SceneManager.LoadScene(sceneName);
    }

	public void Instructions()
	{
		instructionMenu.SetActive(true);
	}

	public void ExitInstruction()
	{
		instructionMenu.SetActive(false);
	}
}
