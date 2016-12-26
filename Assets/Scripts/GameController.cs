using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject foodControllerPrefab;
	private GameObject foodController;

	public GameObject mapControllerPrefab;
	private GameObject mapController;

	public GameObject snakeControllerPrefab;
	private GameObject snakeController;

	public Vector2 mapSize;

	// Use this for initialization
	void Start () 
	{
		foodController = Instantiate (foodControllerPrefab);
		mapController = Instantiate (mapControllerPrefab);
		snakeController = Instantiate (snakeControllerPrefab);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
