using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject gameInfoPrefab;
	private GameObject gameInfo;
	private GameInfoController gameInfoController;

	public GameObject foodControllerPrefab;
	private GameObject foodController;

	public GameObject mapControllerPrefab;
	private GameObject mapController;

	public GameObject LiveRoutinePrefab;
	private GameObject liveRoutineController;

	public Vector2 mapSize;

	private int level;
	private int score;

	// Use this for initialization
	void Start () 
	{
		gameInfo = Instantiate (gameInfoPrefab);
		gameInfoController = gameInfo.GetComponent<GameInfoController> ();

		foodController = Instantiate (foodControllerPrefab);
		mapController = Instantiate (mapControllerPrefab);
		liveRoutineController = Instantiate (LiveRoutinePrefab);
       
        level = 1;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddPoints (int value)
	{
		score += value * level;
		gameInfoController.UpdateScoreText (score);
        PlayerPrefs.SetInt("score", score);

    }

}
