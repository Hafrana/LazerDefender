using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	private int _healthOfTheEnemy;

	public int Health;

	void OnTriggerEnter2D(Collider2D other) 
	{
        Destroy(gameObject);
		Destroy(other.gameObject);
    }
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
