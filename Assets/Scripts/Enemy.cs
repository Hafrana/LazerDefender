using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour 
{
	public GameObject projectile;
	public GameObject explosion;
	public float projectileSpeed;
	public float firingRate = 0.5f;
	public float healthOfTheEnemy = 20f;
	public int scoreValue = 20;
	public AudioClip enemyLazerSound;
	public AudioClip enemyDestroySound;

	private ScoreManager scoreManager;

	void Start()
	{
		scoreManager =  GameObject.Find("ScoreText").GetComponent<ScoreManager>();
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();
		if (beam)
		{
			healthOfTheEnemy -= beam.GetDamage();
			if (healthOfTheEnemy <= 0)
			{
				Debug.Log("Enemy destroyed");
				GameObject boom = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy(gameObject);
				scoreManager.Score(scoreValue);
			}
		} 
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
			AudioSource.PlayClipAtPoint(enemyLazerSound, transform.position);
		}
	}



}