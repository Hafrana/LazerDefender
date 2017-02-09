using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.5f;

	private float _healthOfTheEnemy = 150f;


	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();
		if (beam)
		{
			_healthOfTheEnemy -= beam.GetDamage();
			if (_healthOfTheEnemy <= 0)
			{
				Debug.Log("Enemy destroyed");
				Destroy(gameObject);
			}
		} 
	}
	void Start()
	{
		
	}

	void FireBeam()
	{
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -projectileSpeed, 0);
	}
	void Update()
	{
		float probability = Time.deltaTime * firingRate;
		if (Random.value < probability)
		{
			FireBeam();
		}
	}



}