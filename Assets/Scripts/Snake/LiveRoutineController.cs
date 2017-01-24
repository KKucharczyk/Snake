using UnityEngine;

public class LiveRoutineController : MonoBehaviour
{
    public readonly float gameSpeed;
    private float nextMove = 0.0f;

	private GameObject snakeHandler;
	public GameObject snakePrefab;
	private SnakeController snakeController;

    private IControl snakeControl = new KeyboardControl();

	void Start ()
	{
		snakeHandler = Instantiate (snakePrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
		snakeController = snakeHandler.GetComponent<SnakeController> ();
    }

	void Update ()
	{
        if (Input.anyKeyDown)
            snakeController.setCurrentHeadDirection(snakeControl.getNewDirection(snakeController.getCurrentHeadDirection()));

        if (Time.time > nextMove) 
		{
			nextMove = Time.time + (0.8f - 0.05f * gameSpeed);
            snakeController.moveSnake();

            if (snakeController.isGrowing ()) {
				snakeController.grow ();
			}
			snakeController.updateBodyLocation ();
            snakeController.setPreviousHeadDirection(snakeController.getCurrentHeadDirection());
        }
	}

}


