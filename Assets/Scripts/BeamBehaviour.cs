using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamBehaviour : MonoBehaviour 
{
	public float HitPoints = 100f;

	public float GetDamage()
	{
		return HitPoints;
	}

	public void Hit()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		Destroy(gameObject);
	}
}
