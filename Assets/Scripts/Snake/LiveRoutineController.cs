using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveRoutineController : MonoBehaviour
{
	private float nextMove = 0.0f;
	public float speed;
	private bool grow;

	private GameObject snakeHandler;
	public GameObject SnakePrefab;
    private SnakeController snakeScript;

	private string snakeTag = "Snake";
	private string wallTag = "Wall";
	private string foodTag = "Food";

	void Start ()
	{
		snakeHandler = Instantiate (SnakePrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
		snakeScript = snakeHandler.GetComponent<SnakeController> ();
    }

	void Update ()
	{
		if (Input.anyKeyDown) {
			analyzeKeyPressed ();
		}

		snakeScript.calculateNewHeadPosition ();

		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (1 / speed);
			snakeScript.moveHead ();

			if (grow)
				snakeScript.grow ();
			
			if (snakeScript.getBodySize() > 0) 
				snakeScript.updateBodyLocation ();
			
			grow = false;
		}
	}

	void analyzeKeyPressed() {
		if (Input.GetKey (KeyCode.UpArrow)) {
			updateSnakeOnNewDirection (Direction.UP, 0);
		}  else if (Input.GetKey (KeyCode.DownArrow)) {
			updateSnakeOnNewDirection (Direction.DOWN, 1);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			updateSnakeOnNewDirection (Direction.LEFT, 2);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			updateSnakeOnNewDirection (Direction.RIGHT, 3);
		} else if (Input.GetKey (KeyCode.Space)) {
			grow = true;
		}
	}

	void updateSnakeOnNewDirection(Direction direction, int spriteIndex) {
		snakeScript.setPreviousHeadDirection (snakeScript.getCurrentHeadDirection());
		snakeScript.setCurrentHeadDirection (direction);
		snakeScript.setHeadDirection (direction);
		snakeScript.setHeadSprite (snakeScript.getHeadSprite(spriteIndex));
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == snakeTag || other.tag == wallTag)
			Destroy (gameObject);
		else if (other.tag == foodTag) 
		{
			grow = true;
			Destroy (other.gameObject);
		}
	}
}


