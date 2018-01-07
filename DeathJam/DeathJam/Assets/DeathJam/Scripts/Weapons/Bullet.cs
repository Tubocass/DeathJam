using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	public int team = 0, damage = 1;//0=player, 1=NPC
	[SerializeField] float speed = 4f, timer = 4f;
	//Transform tran;
	void OnEnable () 
	{
		//tran = transform;
		GetComponent<Rigidbody2D>().velocity = transform.up*speed;
		StartCoroutine(Death());
	}
	public void SetBullet(int dmg)
	{
		damage = dmg;
	}
	IEnumerator Death()
	{
		yield return new WaitForSeconds(timer);
		gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D bam)
	{
		switch(bam.collider.tag)
		{
			case "Bullet":
			break;
			case "Enemy":
			{
				var enemy = bam.collider.GetComponent<IHealth>();
				enemy.TakeDamage(damage);
				gameObject.SetActive(false);
			}
			break;
			case "Obstacle":
			{
				gameObject.SetActive(false);
			}
			break;
		}
//		if(bam.collider.CompareTag("Bullet"))
//		{
//			return;
//		}
//		if(bam.collider.CompareTag("Enemy"))
//		{
//			var enemy = bam.collider.GetComponent<IHealth>();
//			enemy.TakeDamage(1);
//		}
//		if(!bam.collider.CompareTag("Weapon"))
//		{
//			StopCoroutine(Death());
//			gameObject.SetActive(false);
//		}
		//Debug.Log(bam.collider.tag);
	}

}
