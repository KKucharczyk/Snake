using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour {

	public GameObject applePrefab;

	private GameController gameController;

	private Vector2 mapSize;

	private GameObject food;


	// Use this for initialization
	void Start () 
	{
		GameObject gC = GameObject.FindWithTag ("GameController");
		if (gC != null) 
		{
			gameController = gC.GetComponent<GameController> ();
			mapSize = gameController.mapSize;
		} 
		else 
		{
			Debug.Log ("FoodController.Start() : Cannot find GameController");
			Destroy (gameObject);
		}

		food = null;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (food == null)
			SpawnFood (applePrefab);
	}


	void SpawnFood (GameObject foodPrefab)
	{
		Vector2 spawnPosition;
		spawnPosition = RandomPosition ();
		if (IsFree (spawnPosition))
			food = Instantiate (foodPrefab, spawnPosition, Quaternion.identity, gameObject.transform); 
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
