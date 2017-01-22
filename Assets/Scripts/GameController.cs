using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour 
{
	public GameObject gameInfoPrefab;
	private GameObject gameInfo;
	private GameInfoController gameInfoController;

	public GameObject foodControllerPrefab;

	public GameObject mapControllerPrefab;

	public GameObject LiveRoutinePrefab;

	public Vector2 mapSize;

	private int level;
	private int score;

	// Use this for initialization
	void Start () 
	{
		gameInfo = Instantiate (gameInfoPrefab);
		gameInfoController = gameInfo.GetComponent<GameInfoController> ();

		Instantiate (foodControllerPrefab);
		Instantiate (mapControllerPrefab);
		Instantiate (LiveRoutinePrefab);
       
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
