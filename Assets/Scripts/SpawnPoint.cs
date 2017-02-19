using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour 
{

	void OnDrawGizmos()
	{
		Gizmos.DrawWireSphere(transform.position, 1);
	}
}
