using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour 
{
	public static int score = 0;
	private Text myText;


	void Start()
	{
		myText = GetComponent<Text>();
	}


	public void Score(int points)
	{
		Debug.Log("Scored");
		score += points;
		myText.text = score.ToString();
	}

	public static void Reset()
	{
		score = 0;
	}
}
