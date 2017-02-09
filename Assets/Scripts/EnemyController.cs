using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public GameObject enemyPrefab;
	public float spawnDelay = 0.5f;

	void Start () 
	{
		SpawnEnemy();
	}

	void SpawnEnemy()
	{
		foreach(Transform child in transform)
		{
			Debug.Log("Spawn Enemy");
			GameObject enemy = Instantiate(enemyPrefab,	child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void SpawnMoreEnemies()
	{
		Transform freePosition = NextFreePosition();
		if (freePosition)
		{
			Debug.Log("Spawn more enemies");
			GameObject enemy = Instantiate(enemyPrefab,	freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition())
		{
			Invoke("SpawnMoreEnemies", spawnDelay);
		}

	}

	void Update () 
	{
		if (AllMembersDead())
		{
			SpawnMoreEnemies();
		}
	}

	Transform NextFreePosition()
	{
		foreach(Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount == 0)
			{
				return childPositionGameObject;
			}
		}
		return null;
	}  

	bool AllMembersDead()
	{
		foreach(Transform childPositionGameObject in transform)
		{
			if (childPositionGameObject.childCount > 0)
			{
				return false;
			}
		}
		return true;
	}
}
