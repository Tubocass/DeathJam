using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
	public GameObject item;
	public GameObject[] possibleItems;
	SpriteRenderer renderer;
	Vector3 spawnPoint;
	bool bActive;

	void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		bActive = renderer.enabled;
		//item = (GameObject)Instantiate(possibleItems[Random.Range(0,1)],transform.position,Quaternion.identity);
		StartCoroutine(SpawnTimer());
	}

	IEnumerator SpawnTimer()
	{
		while(true)
		{
			if(!bActive)
			{
				spawnPoint = new Vector3(Random.Range(-6,6),Random.Range(-4,4));
				transform.position = spawnPoint;
				item = (GameObject)Instantiate(possibleItems[Random.Range(0,2)],transform);
				item.transform.localPosition = Vector2.zero;
				renderer.enabled = true;
				bActive = true;
			}
				yield return new WaitForSeconds(Random.Range(6f,8f));
		}
	}
	public void Destroy()
	{
		renderer.enabled =false;
		bActive = false;
		item = null;
	}
}
