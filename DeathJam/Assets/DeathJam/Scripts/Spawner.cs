using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	[SerializeField] GameObject enemyPrefab;
	GameObject[] enemies = new GameObject[10];

	void Start()
	{
		for (int i = 0; i<enemies.Length;i++)
		{
			enemies[i] = (GameObject)Instantiate(enemyPrefab,transform.position,Quaternion.identity);
			enemies[i].SetActive(false);
		}
		StartCoroutine(Spawn());
	}
	IEnumerator Spawn()
	{
		while(true)
		{
			for(int b = 0; b<enemies.Length; b++)
			{
				if(!enemies[b].activeSelf)
				{
					enemies[b].transform.position = transform.position;
					//enemies[b].transform.rotation = this.transform.rotation;
					enemies[b].SetActive(true);
					break;
				}
			}
			yield return new WaitForSeconds(3f);
		}
		yield return null;
	}


}
