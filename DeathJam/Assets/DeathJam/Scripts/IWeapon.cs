using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
	void PrimaryAttack(Vector2 direction);
	void SecondaryAttack(Vector2 direction);
	//void Equip();
	//void UnEquip();
}
