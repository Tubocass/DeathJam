using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour, IHealth 
{
	public int pointValue = 1;
	[SerializeField] Transform target;
	[SerializeField] GameObject weapon;
	[SerializeField] float moveSpeed;
	Weapon currentWeapon;
	Vector3 movement;
	[SerializeField] int startHealth = 10;
	int health;

	void OnEnable()
	{
		health = startHealth;
	}
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		if(weapon!=null)
		{
			currentWeapon = weapon.GetComponent<Weapon>();
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
	public void TakeDamage(int amount)
	{
		health -=amount;
		if(health<=0)
		{
			gameObject.SetActive(false);
			UnityEventManager.TriggerEvent("Score",pointValue);
		}
	}
	public void Heal(int Amount)
	{}
}
