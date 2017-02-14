using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour 
{

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
