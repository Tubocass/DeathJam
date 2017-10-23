using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	[SerializeField] RectTransform GameOverScreen;
	[SerializeField] ScoreUI scoreUI;
	[SerializeField] EnemySpawner enemySpawn;
	[SerializeField] GameObject Player;
	public void GameOver()
	{
		GameOverScreen.gameObject.SetActive(true);
		enemySpawn.EnableSpawn(false);
	}

	public void StartNewGame()
	{
		scoreUI.points = 0;
		scoreUI.GetComponent<Text>().text = "Points: "+ 0;
		GameOverScreen.gameObject.SetActive(false);
		enemySpawn.EnableSpawn(true);
		Player.transform.position = Vector2.zero;
		Player.SetActive(true);
		Player.GetComponent<PlayerHealth>().Heal(9);
	}
}
