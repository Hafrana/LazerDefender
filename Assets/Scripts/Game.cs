using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour 
{
	public int ScoreValue = 20;
	public ScoreManager ScoreManager;

	public void OnEnemyDestroyed()
	{
		ScoreManager.Score(ScoreValue);
	}

	public void LoadLevel(string name)
	{
		Debug.Log ("New Level load: " + name);
		SceneManager.LoadScene (name);
	}

	public void QuitRequest()
	{
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
		DisableMouseInGame(1);
	}

	void DisableMouseInGame(int level)
	{
		if(level == 1)
		{
			Cursor.visible = false;
		}else
		{
			Cursor.visible = true;
		}
	}
}
