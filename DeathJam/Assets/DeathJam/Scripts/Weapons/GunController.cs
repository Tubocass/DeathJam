using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : Weapon 
{
	public AudioClip shot1;
	public AudioClip shot2;
	public AudioClip shot3;
	public AudioClip drop;
	public AudioClip pickup;
	[SerializeField] Transform Muzzle;
	[SerializeField] int clipSize = 10, bulletDamage = 1;
	[SerializeField][Tooltip("in fractions of a second")] float fireRate = 0.15f;
	bool canFire = true;
	delegate void Fire(GameObject bullet, Vector2 direction);

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
			GameObject bullet = ObjectPool.DrawFromPool("Bullets");
			if(bullet!=null)
			{
				bullet.transform.position = Muzzle.position;
				bullet.transform.rotation = this.transform.rotation;
				bullet.GetComponent<Bullet>().SetBullet(bulletDamage);
				bullet.SetActive(true);
				SoundManager.instance.RandomizeSfx(shot1,shot2,shot3);
				canFire = false;
				StartCoroutine(Cooldown());
			}
		}
	}
		
	public override void SecondaryAttack(Vector2 direction)
	{
		//Pistol whip?

		//triple shot - figure out trig for this
		Debug.Log("Secondary attack called on Gun");
		if(canFire && ammo>=3)
		{
			ammo-=3;
			GameObject[] bullets = ObjectPool.DrawFromPool(3, "Bullets");
			if(bullets!=null)
			{
				float angle = -30;
				for(int b = 0; b<bullets.Length;b++)
				{
					bullets[b].transform.position = Muzzle.position;
					bullets[b].transform.rotation =  Quaternion.AngleAxis(angle,Vector3.forward);
					angle+=30;
					bullets[b].GetComponent<Bullet>().SetBullet(bulletDamage);
					bullets[b].SetActive(true);
					SoundManager.instance.RandomizeSfx(shot1,shot2,shot3);
					canFire = false;
					StartCoroutine(Cooldown());
				}
			}
		}
	}
	public override void Equip()
	{}
	public override void UnEquip()
	{
		transform.parent = null;
		isEquipped = false;
		Destroy(gameObject,3f);
	}
	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(fireRate);
		canFire = true;
	}
}
