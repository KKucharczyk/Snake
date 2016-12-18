using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject applePrefab;
	private GameObject apple;

	public Vector2 mapSize;

	// Use this for initialization
	void Start () 
	{
		apple = null;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (apple == null)
			SpawnApple ();
	}

	void SpawnApple ()
	{
		Vector2 spawnPosition;
		spawnPosition = RandomPosition ();
		if (IsFree (spawnPosition))
			apple = Instantiate (applePrefab, spawnPosition, Quaternion.identity); 
	}

	Vector2 RandomPosition ()
	{
		return new Vector2 
		(
			(int)Random.Range (-mapSize.x, mapSize.x),
			(int)Random.Range (-mapSize.y, mapSize.y)
		);
	}

	bool IsFree (Vector2 position)
	{
		RaycastHit2D hit = Physics2D.Linecast (position, position, LayerMask.GetMask ("Default"));
		return (hit.transform == null);
	}
}
