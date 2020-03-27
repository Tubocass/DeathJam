using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	[SerializeField]public string GameScene;
	public void StartGame()
	{
		SceneManager.LoadScene(GameScene);
	}
	public void Options()
	{}
	public void Exit()
	{
		Application.Quit();
	}
}
