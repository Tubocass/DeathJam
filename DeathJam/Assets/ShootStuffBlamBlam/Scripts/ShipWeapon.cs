using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipWeapon : Weapon
{
	public enum ShipWeaponType{None, MG, Laser, Missile}
	public ShipWeaponType swType = new ShipWeaponType();
}
