using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour 
{
	static MusicPlayer instance = null;
	public bool loop;

	void Awake() 
	{
    	if (instance != null && instance != this) 
    	{
        	Destroy(gameObject);
    	} else 
    	{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
    	}
	}
}
