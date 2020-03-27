using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth 
{
	void TakeDamage(int Amount);
	void Heal(int Amount);
}
