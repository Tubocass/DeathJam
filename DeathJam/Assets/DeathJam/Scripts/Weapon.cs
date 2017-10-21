using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon: MonoBehaviour
{
	public enum WeaponType{Pistol, Sword, MG}
	public WeaponType myType = new WeaponType();
	public int ammo;

	public abstract void PrimaryAttack(Vector2 direction);
	public abstract void SecondaryAttack(Vector2 direction);
	//void Equip();
	//void UnEquip();
}
