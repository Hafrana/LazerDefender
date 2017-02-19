using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float speed = 15f;
	public float pudding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed;
	public AudioClip lazerSound;

	public HealthStat Health;

	float minX;
	float maxX;
	float minY;
	float maxY;


	void Start() 
	{
		ShipMoveByMouse();
		//_healthOfThePlayer.MaxVal = 100;
	}

	void ShipMoveByMouse()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		minX  = leftmost.x + pudding;
		maxX = rightmost.x - pudding;
		Vector3 upmost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 downmost = Camera.main.ViewportToWorldPoint(new Vector3(0,1,distance));
		minY = upmost.y + pudding;
		maxY = downmost.y - pudding;
	}

	void FireBeam()
	{
		Vector3 offset = new Vector3 (0, 0, 0);
		GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();

		if (beam)
		{
			Health.CurrentVal -= beam.GetDamage();
			if (Health.CurrentVal <= 0)
			{
				Die();
				Destroy(beam);
			}

		}
	}
	void Die()
	{
		LevelManager loseLevel = GameObject.Find("LevelManager").GetComponent<LevelManager>();
		loseLevel.LoadLevel("Lose Screen");
		Destroy(gameObject);
	}
	private void Awake()
	{
		Health.Initialize();
	}
    void Update ()
    {
    	if (Input.GetMouseButtonDown(0))
    	{
    		FireBeam();
    		AudioSource.PlayClipAtPoint(lazerSound, transform.position);
     	}

		//restrict the gamespace for ship
		var spaceShipNewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		float newX = Mathf.Clamp(spaceShipNewPos.x, minX, maxX);
		float newY = Mathf.Clamp(spaceShipNewPos.y, minY, maxY);
		transform.position = new Vector3(newX, newY, transform.position.z);
     }
}
