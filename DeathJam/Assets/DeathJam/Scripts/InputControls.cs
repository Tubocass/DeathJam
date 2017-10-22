using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputControls : MonoBehaviour 
{
	[SerializeField] GameObject weapon;
	[SerializeField] Sprite[] weaponImages;// = Image[3];
	[SerializeField] Image currentWeaponIcon;
	[SerializeField] GameObject ammoCount;
	Weapon currentWeapon;

	[SerializeField] LayerMask mask;

	void Start()
	{
		if(weapon!=null)
		{
			currentWeapon = weapon.GetComponent<Weapon>();
			currentWeaponIcon.sprite = weaponImages[(int)currentWeapon.myType];
			ammoCount.GetComponent<Text>().text = "Ammo: "+currentWeapon.ammo;
			currentWeapon.isEquipped = true;
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

		if (currentWeapon!=null && Input.GetMouseButton (0)) 
		{
			//currentWeapon.Attack(dir);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 20f, mask)) 
			{
				Vector3 dir = hit.point-transform.position;
				dir = dir/dir.magnitude;
				currentWeapon.PrimaryAttack(dir);
				ammoCount.GetComponent<Text>().text = "Ammo: "+currentWeapon.ammo;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D bam)
	{
		if(bam.collider.CompareTag("ItemPickup"))
		{
//			IPickup item = bam.collider.GetComponent<ItemPickup>().item;
//			item.Equip(this.transform);
			ItemPickup pickup = bam.collider.GetComponent<ItemPickup>();
			if(pickup.item.CompareTag("Health"))
			{
				GetComponent<PlayerHealth>().Heal(1);
				Destroy(pickup.item);
			}
			pickup.Destroy();
		}
	}
}
