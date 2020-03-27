using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour 
{
	public bool isWeaponEquipped;
	[SerializeField] Weapon[] weapons;
	[SerializeField] Transform weaponSlot;
	Weapon currentWeapon;
	WeaponUI ui;

	void Start()
	{
		ui = GameObject.FindGameObjectWithTag("WeaponUI").GetComponent<WeaponUI>();
		ChangeWeapon(weapons[0]);
	}

	void Update()
	{
//		if(isWeaponEquipped)
//		{
//			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
//			transform.rotation = rot;
//			transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z+90);
//			if(Vector3.Dot(mousePos-transform.position,Vector3.right)>0)//mouse is to the right of us
//			{
//				GetComponent<SpriteRenderer>().flipY = false;
//
//			}else
//			{
//				GetComponent<SpriteRenderer>().flipY = true;
//			}
//		}
	}
	public void EquipWeapon(GameObject weaponObj)
	{
		if(weaponObj.GetComponent<Weapon>() !=null)
		{
			if (currentWeapon != null) 
			{
				//UnequipWeapon();
			}
			weaponObj.transform.parent = weaponSlot;
			weaponObj.transform.position = weaponSlot.position;
			ChangeWeapon(weaponObj.GetComponent<Weapon>());
		}
	}
	public void UnequipWeapon()
	{
		if(currentWeapon!=null)
		{
			currentWeapon.transform.parent = null;
			currentWeapon.isEquipped = false;
			ui.ChangeWeapon(0,0);
			Destroy(currentWeapon.gameObject,3f);
		}
	}
	public void ChangeWeapon(Weapon w)
	{
		currentWeapon = w;
		ui.ChangeWeapon(currentWeapon.myType,currentWeapon.ammo);
		currentWeapon.isEquipped = true;
		isWeaponEquipped = true;
	}
	public void PrimaryAttack(Vector2 dir)
	{
		if (currentWeapon!=null)
		{
			currentWeapon.PrimaryAttack(dir);
			ui.ammoAmount = currentWeapon.ammo;
		}
	}
	public void SecondaryAttack(Vector2 dir)
	{
		if (currentWeapon!=null)
		{
			currentWeapon.SecondaryAttack(dir);
			ui.ammoAmount = currentWeapon.ammo;
		}
	}
}
