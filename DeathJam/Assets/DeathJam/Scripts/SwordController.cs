using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : Weapon 
{
	Animator anim;
	[SerializeField]LayerMask mask;
	bool isEquipped = true;
	void Start()
	{
		anim = GetComponent<Animator>();
	}
	void LateUpdate()
	{
		if(isEquipped)
		{
			Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//			Quaternion rot = Quaternion.LookRotation (transform.position - mousePos, Vector3.forward);
//			transform.rotation = rot;
			
			if(Vector3.Dot(mousePos-transform.position,Vector3.right)>0)//mouse is to the right of us
			{
				//transform.eulerAngles = new Vector3 (0, 0, -50);
				//GetComponent<SpriteRenderer>().flipY = false;

			}else
			{
				//transform.eulerAngles = new Vector3 (0, 0, 50);
				//GetComponent<SpriteRenderer>().flipY = true;
			}
		}
	}

	public override void PrimaryAttack(Vector2 direction)
	{
		anim.SetTrigger("Swing");
		RaycastHit2D hit;
		Vector2 start = transform.position;
		//Cast a line from start point to end point checking collision on blockingLayer.
		hit = Physics2D.Linecast (start, start+direction*2, mask);

		//Check if anything was hit
		if(hit.collider != null)
		{
			Debug.Log(hit.collider.name);
			var enemy = hit.collider.GetComponent<IHealth>();
			if(enemy!=null)
			enemy.TakeDamage(5);
		}
	}
	public override void SecondaryAttack(Vector2 direction)
	{

	}
}
