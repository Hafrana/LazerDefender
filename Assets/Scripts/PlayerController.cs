using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float speed = 15f;
	public float pudding = 0.5f;
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;

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
		GameObject beam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
	}

	void Hit()
	{
		
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
