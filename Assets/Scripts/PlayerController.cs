using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{

	public float Speed = 15f;
	public float Pudding = 0.5f;
	public GameObject Projectile;
	public float ProjectileSpeed;
	public GameObject Explosion;
	public float DieDelay = 0.5f;
	public AudioClip LazerSound;
	public AudioClip PlayerDestroyed;
	public HealthStat PlayerHealth;

	float minX;
	float maxX;
	float minY;
	float maxY;


	void Start() 
	{
		PlayerHealth.Initialize();
		ShipMoveByMouse();
	}

	public void ShipMoveByMouse()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX  = leftmost.x + Pudding;
		maxX = rightmost.x - Pudding;
		Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		minY = upmost.y + Pudding;
		maxY = downmost.y - Pudding;
	}

	void FireBeam()
	{
		Vector3 offset = new Vector3 (0, 0, 0);
		GameObject beam = Instantiate(Projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, ProjectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();

		if (beam)
		{
			PlayerHealth.CurrentVal -= beam.GetDamage();
			if (PlayerHealth.CurrentVal <= 0)
			{
				GameObject boom = Instantiate(Explosion, transform.position, Quaternion.identity) as GameObject;
				Destroy(gameObject);
				AudioSource.PlayClipAtPoint(PlayerDestroyed, transform.position);
				Game loseLevel = GameObject.Find("Game").GetComponent<Game>();  
				loseLevel.LoadLevel("Lose Screen");
				//Invoke("LoadLevel", 1f);


			}
		}
	}


	//void LoadLevel()
	//{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

	//}

    void Update ()
    {
    	if (Input.GetMouseButtonDown(0))
    	{
    		FireBeam();
    		AudioSource.PlayClipAtPoint(LazerSound, transform.position);
     	}

		//restrict the gamespace for ship
		var spaceShipNewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float newX = Mathf.Clamp(spaceShipNewPos.x, minX, maxX);
		float newY = Mathf.Clamp(spaceShipNewPos.y, minY, maxY);
		transform.position = new Vector3(newX, newY, transform.position.z);
     }
}
