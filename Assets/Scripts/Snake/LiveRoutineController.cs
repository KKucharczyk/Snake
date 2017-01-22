using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveRoutineController : MonoBehaviour
{
	private float nextMove = 0.0f;
	public float speed;
	private bool grow;

	private Direction currentDirection = Direction.UNDEFINED;
	private Direction newDirection = Direction.UNDEFINED;

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
		analyzeKeyPressed ();

		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (0.8f - 0.05f * speed);

			updateSnakeOnNewDirection (newDirection, (int) newDirection);
			snakeController.calculateNewHeadPosition ();
			snakeController.moveHead ();

			if (grow || snakeController.isGrowing ()) {
				snakeController.grow ();
				snakeController.toggleGrowing ();
			}
			snakeController.updateBodyLocation ();
			grow = false;
		}
	}

	void analyzeKeyPressed() {
		if (Input.GetKey (KeyCode.UpArrow) && currentDirection != Direction.DOWN) {
			newDirection = Direction.UP;
		}  else if (Input.GetKey (KeyCode.DownArrow) && currentDirection != Direction.UP) {
			newDirection = Direction.DOWN;
		} else if (Input.GetKey (KeyCode.LeftArrow) && currentDirection != Direction.RIGHT) {
			newDirection = Direction.LEFT;
		} else if (Input.GetKey (KeyCode.RightArrow) && currentDirection != Direction.LEFT) {
			newDirection = Direction.RIGHT;
		} else if (Input.GetKey (KeyCode.Space)) {
			grow = true;
		}
	}

	void updateSnakeOnNewDirection(Direction direction, int spriteIndex) {
		currentDirection = newDirection;
		if (direction != DirectionMethods.getOpposite(snakeController.getCurrentHeadDirection ())) {
			snakeController.setPreviousHeadDirection (snakeController.getCurrentHeadDirection ());
			snakeController.setCurrentHeadDirection (direction);
			snakeController.setHeadDirection (direction);
			snakeController.setHeadSprite (snakeController.getHeadSprite (spriteIndex));
		}
	}


}


