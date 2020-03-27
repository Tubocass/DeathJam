using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreUI : MonoBehaviour 
{
	public int points = 0, waves = 1;

	void Start()
	{
		GetComponent<Text>().text =  string.Format("Points: {0}  Waves: {1}", points, waves);
		UnityEventManager.StartListeningInt("Score", AddPoints);
		UnityEventManager.StartListening("NewWave", AddWave);
	}
	void OnDisable()
	{
		UnityEventManager.StopListeningInt("Score", AddPoints);
		UnityEventManager.StopListening("NewWave", AddWave);
	}
	void OnGUI()
	{
		GetComponent<Text>().text =  string.Format("Points: {0}  Waves: {1}", points, waves);	
	}

	public void Reset()
	{
		points = 0;
		waves = 1;
	}
	public void AddPoints(int amount)
	{
		points+= waves*amount;
	
	}
	public void AddWave()
	{
		waves++;
	}
}
