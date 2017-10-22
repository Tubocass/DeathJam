using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : Weapon 
{
	[SerializeField] GameObject bulletFab;
	[SerializeField] Transform Muzzle;
	[SerializeField] int clipSize = 10;
	GameObject[] bulletPool;
	bool canFire = true;

	void OnEnable()
	{
		bulletPool = new GameObject[clipSize];
		for(int b = 0; b<bulletPool.Length; b++)
		{
			bulletPool[b] = (GameObject)Instantiate(bulletFab,Muzzle.position,Quaternion.identity);
			bulletPool[b].SetActive(false);
		}
	}
	void Update()
	{
		if(isEquipped)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
			transform.rotation = rot;
			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z+90);
			if(Vector3.Dot(mousePos-transform.position,Vector3.right)>0)//mouse is to the right of us
			{
				GetComponent<SpriteRenderer>().flipY = false;

			}else
			{
				GetComponent<SpriteRenderer>().flipY = true;
			}
		}
	}
	public override void PrimaryAttack(Vector2 direction)
	{
		if(canFire && ammo>0)
		{
			ammo--;
			//Quaternion q = Quaternion.LookRotation(Direction - Muzzle.position, Vector3.forward);
			for(int b = 0; b<bulletPool.Length; b++)
			{
				if(!bulletPool[b].activeSelf)
				{
					bulletPool[b].transform.position = Muzzle.position;
					bulletPool[b].transform.rotation = this.transform.rotation;
					bulletPool[b].SetActive(true);
					break;
				}
			}
			canFire = false;
			StartCoroutine(Cooldown());
		}
	}
	public override void SecondaryAttack(Vector2 direction)
	{
		//Pistol whip
	}
	public override void Equip()
	{}
	public override void UnEquip()
	{
		transform.parent = null;
		isEquipped = false;
		Destroy(gameObject,6f);
	}
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(0.15f);
		canFire = true;
	}
}
