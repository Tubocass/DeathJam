using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
	Animator anim;
	int hits = 0, maxHits = 3;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	public bool TakeDamage(int amount)
	{
		if(hits<maxHits)
		{
			hits += amount;
			anim.SetInteger("Hits",hits);
			if(hits>=maxHits)
			{
				gameObject.SetActive(false);
			}
		}
		return hits>=maxHits;
	}

	public void AddHealth(int amount)//return true if healed, return false if already at full health
	{
		hits-=amount;
		if(hits<0)
		hits=0;
		anim.SetInteger("Hits",hits);
	}

}
