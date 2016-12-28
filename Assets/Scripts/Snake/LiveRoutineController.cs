using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveRoutineController : MonoBehaviour
{
	private float nextMove = 0.0f;
	public float speed;
	private bool grow;
	private bool notMoved= true;

	private GameObject snakeHandler;
	public GameObject snakePrefab;
	private SnakeController snakeController;

	void Start ()
	{
		snakeHandler = Instantiate (snakePrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
		snakeController = snakeHandler.GetComponent<SnakeController> ();
    }

	void Update ()
	{
		if (Input.anyKeyDown && notMoved) {
			analyzeKeyPressed ();
			notMoved = false;
		}

		snakeController.calculateNewHeadPosition ();

		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (1 / speed);
			snakeController.moveHead ();
			notMoved = true;

			if (grow || snakeController.isGrowing ()) {
				snakeController.grow ();
				snakeController.toggleGrowing ();
			}
			
			if (snakeController.getBodySize() > 0) 
				snakeController.updateBodyLocation ();
			
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
		if (direction != DirectionMethods.getOpposite(snakeController.getCurrentHeadDirection ())) {
			snakeController.setPreviousHeadDirection (snakeController.getCurrentHeadDirection ());
			snakeController.setCurrentHeadDirection (direction);
			snakeController.setHeadDirection (direction);
			snakeController.setHeadSprite (snakeController.getHeadSprite (spriteIndex));
		}
	}


}


