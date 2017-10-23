using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour 
{
	public int points = 0;
	//UnityAction<int> score;

	void Start()
	{
		GetComponent<Text>().text = "Points: "+ points;
		UnityEventManager.StartListeningInt("Score", AddPoints);
		//score = AddPoints;
		//EnemyController.Death.AddListener(score);
	}
	void OnDisable()
	{

	}
	public void AddPoints(int amount)
	{
		points+= amount;
		GetComponent<Text>().text = "Points: "+ points;
	}
}
