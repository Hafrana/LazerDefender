using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float speed = 15f;
	public float pudding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed;

	private float _healthOfThePlayer = 350f;
	//public float firingRate = 0.2f;

	float minX;
	float maxX;
	float minY;
	float maxY;


	void Start() 
	{
		//Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

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
		Vector3 offset = new Vector3 (0, 1, 0);
		GameObject beam = Instantiate(projectile, transform.position + offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	void OnTriggerEnter2D(Collider2D collider) 
	{
		BeamBehaviour beam = collider.gameObject.GetComponent<BeamBehaviour>();
		if (beam)
		{
			_healthOfThePlayer -= beam.GetDamage();
			if (_healthOfThePlayer <= 0)
			{
				Destroy(gameObject);
				Destroy(beam);
			}
		}
	}

     void Update ()
     {

     	if (Input.GetMouseButtonDown(0))
     	{
     		FireBeam();
			//InvokeRepeating("FireBeam", 0.0000001f, firingRate);
     	}
     	//if (Input.GetMouseButtonUp(0))
     	//{
     	//	CancelInvoke("FireBeam");
     	//}
		var spaceShipNewPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	
  		//restrict the gamespace for ship
		float newX = Mathf.Clamp(spaceShipNewPos.x, minX, maxX);
		float newY = Mathf.Clamp(spaceShipNewPos.y, minY, maxY);
		transform.position = new Vector3(newX, newY, transform.position.z);
   
     }
}
