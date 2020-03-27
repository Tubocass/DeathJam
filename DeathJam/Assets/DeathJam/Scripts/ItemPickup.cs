using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour 
{
	public GameObject item;
	public GameObject[] possibleItems;
	SpriteRenderer spriteRend;
	Vector3 spawnPoint;
	bool bActive;

	void Start()
	{
		spriteRend = GetComponent<SpriteRenderer>();
		bActive = spriteRend.enabled;
		item = (GameObject)Instantiate(possibleItems[Random.Range(0,1)],transform.position,Quaternion.identity);
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
				item = (GameObject)Instantiate(possibleItems[Random.Range(0,possibleItems.Length)],transform);
				item.transform.localPosition = Vector2.zero;
				spriteRend.enabled = true;
				bActive = true;
			}else 
			{
				Disable();
			}
				yield return new WaitForSeconds(Random.Range(6f,8f));
		}
	}
	public void TakeItem()
	{
		item = null;
	}
	public void Disable()
	{
		spriteRend.enabled =false;
		bActive = false;
		if(item!=null)
		{
			Destroy(item);
			item = null;
		}

	}
}
