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
	public int[] waveAmounts;
	int killed, wave;

	void OnEnable()
	{
		UnityEventManager.StartListeningInt("Score",CountKilled);
	}
	void OnDisable()
	{
		UnityEventManager.StopListeningInt("Score",CountKilled);
	}
	void Start()
	{
		StartCoroutine(GenerateWave());
	}
	public void GameOver()
	{
		GameOverScreen.gameObject.SetActive(true);
		enemySpawn.EnableSpawn(false);
		Player.GetComponent<PlayerWeapon>().UnequipWeapon();
		StopCoroutine(GenerateWave());
	}

	public void StartNewGame()
	{
		scoreUI.points = 0;
		scoreUI.waves = 0;
		GameOverScreen.gameObject.SetActive(false);
		//enemySpawn.EnableSpawn(true);
		Player.transform.position = Vector2.zero;
		Player.SetActive(true);
		Player.GetComponent<PlayerHealth>().Heal(9);
		StartCoroutine(GenerateWave());
	}
	void CountKilled(int i)
	{
		killed+=1;
	}
	IEnumerator GenerateWave()
	{
		while(wave<waveAmounts.Length)
		{
			StartCoroutine(enemySpawn.Spawn(waveAmounts[wave]));
			killed = 0;
			while(killed<waveAmounts[wave])
			{
				yield return null;
			}
			enemySpawn.EnableSpawn(false);
			yield return new WaitForSeconds(5f);
			wave++;
			UnityEventManager.TriggerEvent("NewWave");
		}
	}
}
