using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour 
{
	[SerializeField] Sprite[] weaponImages;// = Image[3];
	[SerializeField] Image currentWeaponIcon;
	[SerializeField] Text ammoCounter;
	public int ammoAmount;

	void Start () 
	{
		currentWeaponIcon.sprite = weaponImages[0];
	}

	void OnGUI () 
	{
		ammoCounter.text = "Ammo: "+ ammoAmount;
	}
	public void ChangeWeapon(Weapon.WeaponType type, int ammo)
	{
		currentWeaponIcon.sprite = weaponImages[(int)type];
		ammoAmount = ammo;
		ammoCounter.text = "Ammo: "+ ammoAmount;
	}
}
