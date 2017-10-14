using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	[SerializeField] Transform target;
	[SerializeField] GameObject weapon;
	[SerializeField] float moveSpeed;
	IWeapon currentWeapon;
	Vector3 movement;
	[SerializeField] float startHealth = 10;
	float health;

	void OnEnable()
	{
		health = startHealth;
	}
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		if(weapon!=null)
		{
			currentWeapon = weapon.GetComponent<IWeapon>();
		}
	}
	void Update()
	{
		if(target!=null)
		{
			movement = (target.position-transform.position).normalized;
			Vector3 targetDir  = transform.position + (movement * moveSpeed * Time.deltaTime);//paranthesis for clarity
			transform.position = Vector3.MoveTowards(transform.position,targetDir,1f);
		}
	}
	public void TakeDamage(float amount)
	{
		health -=amount;
		if(health<=0)
		{
			gameObject.SetActive(false);
		}

	}
}
