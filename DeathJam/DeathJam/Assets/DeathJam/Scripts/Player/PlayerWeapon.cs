using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour 
{
	[SerializeField] GameObject weapon;
	[SerializeField] Transform weaponSlot;
	Weapon currentWeapon;
	WeaponUI ui;

	void Start()
	{
		EquipWeapon(weapon);
		ui = GameObject.FindGameObjectWithTag("WeaponUI").GetComponent<WeaponUI>();
	}
	public void EquipWeapon(GameObject weaponObj)
	{
		if(weaponObj!=null)
		{
			if (currentWeapon != null) 
			{
				currentWeapon.UnEquip ();
			}
			currentWeapon = weaponObj.GetComponent<Weapon>();
			if(currentWeapon!=null)
			{
				weaponObj.transform.parent = weaponSlot;
				weaponObj.transform.position = weaponSlot.position;
				currentWeapon = weaponObj.GetComponent<Weapon>();
				ui.ChangeWeapon(currentWeapon.myType,currentWeapon.ammo);
				currentWeapon.isEquipped = true;
			}
		}
	}
		
	public void PrimaryAttack(Vector2 dir)
	{
		if (currentWeapon!=null)
		{
			currentWeapon.PrimaryAttack(dir);
			ui.ammoAmount = currentWeapon.ammo;
		}
	}
}
