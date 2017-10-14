using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControls : MonoBehaviour 
{

	[SerializeField] float moveSpeed;// minFOV, maxFOV, scrollSpeed;
	[SerializeField] GameObject weapon;
	IWeapon currentWeapon;
	Vector3 movement;
	[SerializeField] LayerMask mask;
	Transform tran;
	// Update is called once per frame
	void Start()
	{
		//mask = 1<<LayerMask.NameToLayer("Ground");
		tran = transform;
		if(weapon!=null)
		{
			currentWeapon = weapon.GetComponent<IWeapon>();
		}
	}
	void Update () 
	{
		float lastInputX = Input.GetAxis ("Horizontal");
		float lastInputY = Input.GetAxis ("Vertical");
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

//		float lastInputScroll = Input.GetAxis("Mouse ScrollWheel");
//				if(lastInputScroll>0f || lastInputScroll<0f)
//		{
//			Camera.main.orthographicSize -= lastInputScroll* scrollSpeed;
//			Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minFOV, maxFOV);
//		}

		if(lastInputX != 0f || lastInputY != 0f)
		{
			movement = new Vector3(lastInputX, lastInputY, 0);
			Vector3 targetDir  = transform.position + movement * moveSpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position,targetDir,1f);
		}

		if (Input.GetMouseButton (0)) 
		{
			//currentWeapon.Attack(dir);
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 20f, mask)) 
			{
				Vector3 dir = hit.point-transform.position;
				currentWeapon.Attack();
			}
		}
		if(currentWeapon!=null)
		{
			Quaternion rot = Quaternion.LookRotation (weapon.transform.position - mousePos, Vector3.forward);
			weapon.transform.rotation = rot;
			weapon.transform.eulerAngles = new Vector3 (0, 0, weapon.transform.eulerAngles.z+90);
			if(Vector3.Dot(mousePos-transform.position,Vector3.right)>0)//mouse is to the right of us
			{
				weapon.GetComponent<SpriteRenderer>().flipY = false;

			}else
			{
				weapon.GetComponent<SpriteRenderer>().flipY = true;
			}
		}
	}

}
