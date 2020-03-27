using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMover : MonoBehaviour 
{
	[SerializeField] float moveSpeed;
	Transform tran;
	Vector3 movement;
	Rigidbody2D rigid;
	void Start () 
	{
		tran = transform;
		rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		float lastInputX = Input.GetAxis ("Horizontal");
//		float lastInputY = Input.GetAxis ("Vertical");
//
//		if(lastInputX != 0f || lastInputY != 0f)
//		{
//			movement = new Vector3(lastInputX, lastInputY, 0);
//			Vector3 targetDir  = tran.position + movement * moveSpeed * Time.deltaTime;
//			tran.position = Vector3.MoveTowards(tran.position,targetDir,1f);
//		}
//	}

	public void Move(Vector3 direction)
	{
//		direction = direction/direction.magnitude;
		Vector3 targetDir  = tran.position + direction * moveSpeed * Time.deltaTime;
		if(rigid!=null)
		{
			rigid.MovePosition(targetDir);
		}
		else{
			tran.position = Vector3.MoveTowards(tran.position,targetDir,1f);
		}
	}
}
