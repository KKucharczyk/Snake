using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveRoutineController : MonoBehaviour
{
	private float nextMove = 0.0f;
	public float speed;

	private Direction currentHeadDirection = Direction.UNDEFINED;

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

			updateSnakeOnNewDirection (currentHeadDirection, (int)currentHeadDirection);
			snakeController.calculateNewHeadPosition ();
			snakeController.moveHead ();

			if (snakeController.isGrowing ()) {
				snakeController.grow ();
				snakeController.toggleGrowing ();
			}
			snakeController.updateBodyLocation ();
		}
	}

	void analyzeKeyPressed() {
		if (Input.GetKey (KeyCode.UpArrow) && currentHeadDirection != Direction.DOWN) {
            currentHeadDirection = Direction.UP;
		}  else if (Input.GetKey (KeyCode.DownArrow) && currentHeadDirection != Direction.UP) {
            currentHeadDirection = Direction.DOWN;
		} else if (Input.GetKey (KeyCode.LeftArrow) && currentHeadDirection != Direction.RIGHT) {
            currentHeadDirection = Direction.LEFT;
		} else if (Input.GetKey (KeyCode.RightArrow) && currentHeadDirection != Direction.LEFT) {
            currentHeadDirection = Direction.RIGHT;
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


