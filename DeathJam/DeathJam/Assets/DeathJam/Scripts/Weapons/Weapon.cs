using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
	public enum WeaponType{None=0,Pistol=1, Sword=2, MG=3}
	public WeaponType myType = new WeaponType();
	public int ammo;
	[HideInInspector]public bool isEquipped = false;

	public abstract void PrimaryAttack(Vector2 direction);
	public abstract void SecondaryAttack(Vector2 direction);
	public abstract void Equip();
	public abstract void UnEquip();
}
