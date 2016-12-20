using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour {

	public GameObject groundPrefab;
	public GameObject wallPrefab;

	private GameController gameController;

	private Vector2 mapSize;

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
			Debug.Log ("MapController.Start() : Cannot find GameController");
			Destroy (gameObject);
		}

		CreateMap ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public void CreateMap ()
	{
		for (float x = -mapSize.x; x <= mapSize.x; ++x) 
		{
			for (float y = -mapSize.y; y <= mapSize.y; ++y) 
			{
				Instantiate (groundPrefab, new Vector2 (x, y), Quaternion.identity, transform);
				if ((x == -mapSize.x || x == mapSize.x) || (y == -mapSize.y || y == mapSize.y))
					Instantiate (wallPrefab, new Vector2 (x, y), Quaternion.identity, transform);	
			}
		}
	}
}
