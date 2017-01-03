using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoController : MonoBehaviour {

	public GUIText LevelText;
	public GUIText ScoreText;

	// Use this for initialization
	void Start () {
		LevelText.text = "Level 1";
		ScoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateLevelText (int level)
	{
		LevelText.text = "Level " + level;
	}

	public void UpdateScoreText (int score)
	{
		ScoreText.text = "Score: " + score;
	}
}
