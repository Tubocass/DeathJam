using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	public int[] waveAmounts;
	public int enemyNumber = 10;
	[SerializeField] RectTransform GameOverScreen;
	[SerializeField] ScoreUI scoreUI;
	[SerializeField] EnemySpawner enemySpawn;
	[SerializeField] GameObject Player;
	[SerializeField] GameObject bulletFab, enemyFab;
	GameObject[] enemies;
	Transform[] spawnPoints;
	int killed, wave, spawned;

	void OnEnable()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		UnityEventManager.StartListeningInt("Score",CountKilled);
		ObjectPool.CreatePool("Bullets", 20, bulletFab);
		ObjectPool.CreatePool("Enemies",enemyNumber, enemyFab);
		enemies = ObjectPool.DrawFromPool(enemyNumber,"Enemies");
		//for different enemy types we could have diferent pools
		spawnPoints = GetComponentsInChildren<Transform>();

	}
	void OnDisable()
	{
		UnityEventManager.StopListeningInt("Score",CountKilled);
		ObjectPool.CloseDictionary();
	}
	void Start()
	{
		StartCoroutine(GenerateWave());
	}

	public void GameOver()
	{
		GameOverScreen.gameObject.SetActive(true);
		//enemySpawn.DisableSpawn();
		Player.GetComponent<PlayerWeapon>().UnequipWeapon();
		for(int e=0;e< enemies.Length;e++)
		{
			enemies[e].SetActive(false);
		}
		StopCoroutine(GenerateWave());
	}

	public void StartNewGame()
	{
		scoreUI.Reset();
		wave = 0;
		GameOverScreen.gameObject.SetActive(false);
		Player.transform.position = Vector2.zero;
		Player.SetActive(true);
		Player.GetComponent<PlayerHealth>().Heal(9);
		StartCoroutine(GenerateWave());
	}
	void CountKilled(int i)
	{
		killed+=1;
		//amount can be more than one for harder enemies
	}
	IEnumerator GenerateWave()
	{
		do{
			killed = 0;
			spawned = 0;
			Vector2 point = (Vector2)spawnPoints[Random.Range(1,spawnPoints.Length)].position;

			while(killed<waveAmounts[wave])
			{
				for(int b = 0; b<enemies.Length; b++)
				{
					if(!enemies[b].activeSelf && spawned< waveAmounts[wave])
					{
						enemies[b].transform.position = Random.insideUnitCircle +point;
						enemies[b].SetActive(true);
						spawned++;
						//yield return new WaitForSeconds(.4f);
						//break;
					}
				}
				yield return null;
			}
			wave+=1;
			yield return new WaitForSeconds(5f);
			UnityEventManager.TriggerEvent("NewWave");
		}while(wave<waveAmounts.Length);
		//GameOver();
	}

//	public IEnumerator Spawn(int amount)
//	{
//		int spawned = 0;
//		Vector2 point = (Vector2)spawnPoints[Random.Range(1,spawnPoints.Length)].position;
//		while(spawned<amount)
//		{
//			for(int b = 0; b<enemies.Length; b++)
//			{
//				if(!enemies[b].activeSelf)
//				{
//					enemies[b].transform.position = Random.insideUnitCircle +point;
//					//enemies[b].transform.rotation = this.transform.rotation;
//					enemies[b].SetActive(true);
//					spawned++;
//					//break;
//					yield return new WaitForSeconds(0.2f);
//				}
//			}
//			yield return new WaitForSeconds(Random.Range(0.2f,1f));
//		}
//	}
}
