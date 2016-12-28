using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : AbstractBodyController
{
	private Direction previousDirection;
	private Vector2 newPosition;

	private Vector2 movmentUp = new Vector2 (0.0f, 1.0f);
	private Vector2 movmentDown = new Vector2 (0.0f, -1.0f);
	private Vector2 movmentLeft = new Vector2 (-1.0f, 0.0f);
	private Vector2 movmentRight = new Vector2 (1.0f, 0.0f);

	private string snakeTag = "Snake";
	private string wallTag = "Wall";
	private string foodTag = "Food";

	private Rigidbody2D rigidbody;
	private Vector2 movment;
	private bool isGrowing = false;

	void Awake() {
		rigidbody = this.GetComponent<Rigidbody2D> ();
		rigidbody.position = new Vector2 (0.0f, 0.0f);
	}

	public Vector2 getCurrentPosition() {
		return rigidbody.position;
	}

	public void setCurrentPosition(Vector2 position) {
		rigidbody.position = position;
	}

	public Direction getPreviousDirection() {
		return previousDirection;
	}

	public void setPreviousDirection(Direction direction) {
		this.previousDirection = direction;
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
			Destroy (gameObject);
		else if (other.tag == foodTag) 
		{
			isGrowing = true;
			Destroy (other.gameObject);
		}
	}

	public bool getIsGrowing() {
		return isGrowing;
	}

	public void toggleIsGrowing() {
		isGrowing = false;
	}
}


