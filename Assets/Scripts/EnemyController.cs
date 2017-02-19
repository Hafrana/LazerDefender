using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	public GameObject[] EnemiesPrefab;
	public float SpawnDelay = 0.5f;
	public Game Game;

	void Start () 
	{
		SpawnEnemy();
	}
	 
	void SpawnEnemy()
	{
		foreach(Transform child in transform)
		{
			Debug.Log("Spawn Enemy");
			GameObject enemy = Instantiate(EnemiesPrefab[Random.Range(0, EnemiesPrefab.Length)],	child.transform.position, Quaternion.identity) as GameObject;
			enemy.GetComponent<Enemy>().Game = Game;
			enemy.transform.parent = child;
		}
	}

	void SpawnMoreEnemies()
	{
		Transform freePosition = NextFreePosition();
		if (freePosition)
		{
			Debug.Log("Spawn more enemies");
			GameObject enemy = Instantiate(EnemiesPrefab[Random.Range(0, EnemiesPrefab.Length)], freePosition.position, Quaternion.identity) as GameObject;
			enemy.GetComponent<Enemy>().Game = Game;
			enemy.transform.parent = freePosition;
		}

		if(NextFreePosition())
		{
			Invoke("SpawnMoreEnemies", SpawnDelay);
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
