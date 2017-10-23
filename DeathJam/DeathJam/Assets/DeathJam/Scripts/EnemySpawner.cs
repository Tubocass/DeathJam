using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
	[SerializeField] GameObject enemyPrefab;
	public int enemyNumber = 10;
	GameObject[] enemies;
	Transform[] spawnPoints;// = new Transform[4];
	//bool bActive;

	void Start()
	{
		enemies = new GameObject[enemyNumber];
		spawnPoints = GetComponentsInChildren<Transform>();
		for (int i = 0; i<enemies.Length;i++)
		{
			enemies[i] = (GameObject)Instantiate(enemyPrefab,transform.position,Quaternion.identity);
			enemies[i].SetActive(false);
		}
		//bActive = true;
		//StartCoroutine(Spawn());
	}
	public void EnableSpawn(bool state)
	{
		if(state ==false)
		{
			//bActive = false;
			StopCoroutine(Spawn(0));
			for(int b = 0; b<enemies.Length; b++)
			{
				enemies[b].SetActive(false);
			}
		}else
		{
			//bActive = true;
			//StartCoroutine(Spawn());
		}
	}
	public IEnumerator Spawn(int amount)
	{
		int spawned = 0;
		while(spawned<amount)
		{
			for(int b = 0; b<enemies.Length; b++)
			{
				if(!enemies[b].activeSelf)
				{
					enemies[b].transform.position = spawnPoints[Random.Range(1,spawnPoints.Length)].position;
					//enemies[b].transform.rotation = this.transform.rotation;
					enemies[b].SetActive(true);
					spawned++;
					break;
				}
			}
			yield return new WaitForSeconds(Random.Range(0.2f,2f));
		}
	}


}
