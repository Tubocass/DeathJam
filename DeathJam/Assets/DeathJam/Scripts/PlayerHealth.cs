using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth 
{
	public int startHearts = 1, maxHearts = 3;
	[SerializeField] GameObject heartFab;
	[SerializeField] RectTransform healthHUD;
	HealthBar currentHeart;
	GameObject[] hearts;
	int activeHeart;
	bool isDead = false;

	void Start()
	{
		hearts = new GameObject[maxHearts];
		for(int h = 0; h<maxHearts;h++)
		{
			hearts[h] = (GameObject)Instantiate(heartFab,healthHUD);
			if(h >= startHearts)
			{
				hearts[h].SetActive(false);
			}
		}
		activeHeart = startHearts-1;
		currentHeart = hearts[activeHeart].GetComponent<HealthBar>();
	}

	public void TakeDamage(int amount)
	{
		if (currentHeart.TakeDamage(amount))
		{
			activeHeart -= 1;
			if(activeHeart<0)
			{
				isDead = true;
				activeHeart = 0;
			}else
			{
				currentHeart = hearts[activeHeart].GetComponent<HealthBar>();
			}

		}
	}
	public void Heal(int amount)
	{
		currentHeart.AddHealth(3);
		if(activeHeart<maxHearts-1)
		{
			activeHeart += 1;
			hearts[activeHeart].SetActive(true);
			currentHeart = hearts[activeHeart].GetComponent<HealthBar>();
			currentHeart.AddHealth(3);

		}
	}

	void OnCollisionEnter2D(Collision2D bam)
	{
		if(bam.collider.CompareTag("Enemy"))
		{
			TakeDamage(1);
		}
	}
}
