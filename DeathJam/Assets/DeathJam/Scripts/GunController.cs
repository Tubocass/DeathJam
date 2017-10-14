using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, IWeapon {

	[SerializeField]GameObject bulletFab;
	[SerializeField]Transform Muzzle;
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
	public void Attack(Vector3 Position)
	{
		if(canFire)
		{
			//Quaternion q = Quaternion.LookRotation(Direction - Muzzle.position, Vector3.forward);
			for(int b = 0; b<bulletPool.Length; b++)
			{
				if(!bulletPool[b].activeSelf)
				{
					bulletPool[b].transform.position = Muzzle.position;
					bulletPool[b].transform.rotation = this.transform.rotation;
					bulletPool[b].SetActive(true);
					//bulletPool[b].transform.LookAt(Direction,Vector3.forward);//Rotate(Vector3.forward,Vector3.Angle(transform.up,Direction));
//					Quaternion rot = Quaternion.LookRotation (transform.position - Position, Vector3.forward);
//					bulletPool[b].transform.rotation = rot;
//					bulletPool[b].transform.eulerAngles = new Vector3 (0, 0, bulletPool[b].transform.eulerAngles.z);
					//GetComponent<Rigidbody2D>().angularVelocity = 0;
					break;
				}
			}
			canFire = false;
			StartCoroutine(Cooldown());
		}
	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(0.25f);
		canFire = true;
	}
}
