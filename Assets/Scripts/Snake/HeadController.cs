using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadController : AbstractBodyController
{
	private Direction previousDirection;
	private Vector2 newPosition;

    private Vector2 movment;
    private bool isGrowing = false;

	private readonly string snakeTag = "Snake";
	private readonly string wallTag = "Wall";
	private readonly string foodTag = "Food";

	void Awake() {
        this.GetComponent<Rigidbody2D>().position = new Vector2 (0.0f, 0.0f);
	}

	public void setSprite(Sprite sprite) {
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public Vector2 getMovment() {
		return movment;
	}

	public void calculateNewPosition() {
		this.newPosition = (this.getCurrentPosition() + getMovment());
	}

	public void setMovment(Direction direction) {
		switch (direction) {
		case Direction.UP:
			{
				movment = movmentUp;
				break;
			}
		case Direction.DOWN:
			{
				movment = movmentDown;
				break;
			}
		case Direction.LEFT:
			{
				movment = movmentLeft;
				break;
			}
		case Direction.RIGHT:
			{
				movment = movmentRight;
				break;
			}
		}
	}

	public void move() {
		this.setCurrentPosition(this.newPosition);
		this.GetComponent<Rigidbody2D> ().transform.position = this.getCurrentPosition ();
	}

	public bool isDirectionChanged() {
		return this.getCurrentDirection () != this.getPreviousDirection ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
        if (other.tag == wallTag || other.tag == snakeTag)
        {
            SceneManager.LoadScene("EndGame");
            Destroy(gameObject);
        }
        else if (other.tag == foodTag)
        {
            isGrowing = true;
            Destroy(other.gameObject);
        }
	}

	public bool getIsGrowing() {
		return isGrowing;
	}

	public void toggleIsGrowing() {
		isGrowing = false;
	}
}


