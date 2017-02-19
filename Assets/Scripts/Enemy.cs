using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public GameObject Projectile;
	public GameObject Explosion;
	public float ProjectileSpeed;
	public float FiringRate = 0.5f;
	public float EnemyHealth;
	public AudioClip EnemyLazerSound;
	//public AudioClip EnemyDestroySound;
	public Game Game;


	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();
		if (beam)
		{
			EnemyHealth -= beam.GetDamage();
			if (EnemyHealth <= 0f)
			{
				Debug.Log("Enemy destroyed");
				GameObject boom = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy(gameObject);
				beam.Hit();
				Game.OnEnemyDestroyed();
			}
		} 
	}
	void FireBeam()
	{
		GameObject beam = Instantiate(Projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -ProjectileSpeed, 0);
	}

	void Update()
	{
		float probability = Time.deltaTime * FiringRate;
		if (Random.value < probability)
		{
			FireBeam();
			AudioSource.PlayClipAtPoint(EnemyLazerSound, transform.position);
		}
	}
}