using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour 
{
	//public int startHealth = 10;
	[SerializeField] float moveSpeed;// minFOV, maxFOV, scrollSpeed;
	[SerializeField] GameObject weapon;
	IWeapon currentWeapon;
	Vector3 movement;
	[SerializeField] LayerMask mask;
	//Transform tran;
	//int health;
	// Update is called once per frame
	void Start()
	{
		//mask = 1<<LayerMask.NameToLayer("Ground");
		//health = startHealth;
		//tran = transform;
		if(weapon!=null)
		{
			currentWeapon = weapon.GetComponent<IWeapon>();
		}
	}
	void Update () 
	{
//		float lastInputX = Input.GetAxis ("Horizontal");
//		float lastInputY = Input.GetAxis ("Vertical");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//		float lastInputScroll = Input.GetAxis("Mouse ScrollWheel");
//				if(lastInputScroll>0f || lastInputScroll<0f)
//		{
//			Camera.main.orthographicSize -= lastInputScroll* scrollSpeed;
//			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minFOV, maxFOV);
//		}
//
//		if(lastInputX != 0f || lastInputY != 0f)
//		{
//			movement = new Vector3(lastInputX, lastInputY, 0);
//			Vector3 targetDir  = transform.position + movement * moveSpeed * Time.deltaTime;
//			transform.position = Vector3.MoveTowards(transform.position,targetDir,1f);
//		}

		if (currentWeapon!=null && Input.GetMouseButtonUp (0)) 
		{
			//currentWeapon.Attack(dir);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 20f, mask)) 
			{
				Vector3 dir = hit.point-transform.position;
				dir = dir/dir.magnitude;
				currentWeapon.PrimaryAttack(dir);
			}
		}
	}

//	public void TakeDamage(int amount)
//	{
//		health-=amount;
//	}
//	public void Heal(int amount)
//	{
//		health+=amount;
//	}

	void OnCollisionEnter2D(Collision2D bam)
	{
		if(bam.collider.CompareTag("Enemy"))
		{
			//TakeDamage(1);
		}
	}
}
