using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject foodControllerPrefab;
	private GameObject foodController;

	public GameObject mapControllerPrefab;
	private GameObject mapController;

	public GameObject LiveRoutinePrefab;
	private GameObject liveRoutineController;

	public Vector2 mapSize;

	public int score;

	// Use this for initialization
	void Start () 
	{
		foodController = Instantiate (foodControllerPrefab);
		mapController = Instantiate (mapControllerPrefab);
		liveRoutineController = Instantiate (LiveRoutinePrefab);

		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddPoints (int value)
	{
		score += value;
	}

}
