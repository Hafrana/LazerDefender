using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

	public float speed = 15f;
	public float pudding = 0.5f;

	float minX;
	float maxX;
	float minY;
	float maxY;


	void Start() 
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
		
 
     void Update ()
     {
         if (Input.GetKey(KeyCode.LeftArrow))
         {
			transform.position += Vector3.left * speed * Time.deltaTime;
         } 
         else if (Input.GetKey(KeyCode.RightArrow))
         {
			transform.position += Vector3.right * speed * Time.deltaTime;
         } 
         else if (Input.GetKey(KeyCode.UpArrow))
         {
             transform.position += Vector3.up * speed * Time.deltaTime;
         }
         else if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += Vector3.down * speed * Time.deltaTime;
         }

         //restrict the gamespace for ship
         float newX = Mathf.Clamp(transform.position.x, minX, maxX);
         float newY = Mathf.Clamp(transform.position.y, minY, maxY);
         transform.position = new Vector3(newX, newY, transform.position.z);
     }
 
	void OnMouseDrag(){
       
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;
            transform.position = mousePos;
       
    }
}
