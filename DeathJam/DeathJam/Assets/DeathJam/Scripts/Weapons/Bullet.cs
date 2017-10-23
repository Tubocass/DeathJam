using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public int team = 0;//0=player, 1=NPC
	[SerializeField] float speed = 4f, timer = 4f;
	//Transform tran;
	void OnEnable () 
	{
		//tran = transform;
		GetComponent<Rigidbody2D>().velocity = transform.right*speed;
		StartCoroutine(Death());
	}

	IEnumerator Death()
	{
		yield return new WaitForSeconds(timer);
		gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D bam)
	{
		if(bam.collider.CompareTag("Enemy"))
		{
			var enemy = bam.collider.GetComponent<IHealth>();
			enemy.TakeDamage(1);
		}
		if(!bam.collider.CompareTag("Weapon"))
		{
			StopCoroutine(Death());
			gameObject.SetActive(false);
		}
	}

}
