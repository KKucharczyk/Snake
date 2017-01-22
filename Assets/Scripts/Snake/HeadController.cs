using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadController : AbstractBodyController
{
    private Vector2 movement;
    private bool isGrowing = false;

	private readonly string snakeTag = "Snake";
	private readonly string wallTag = "Wall";
	private readonly string foodTag = "Food";

	public Vector2 getMovement() {
		return movement;
	}

    public void setMovement(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP:
                {
                    movement = this.movmentUp;
                    break;
                }
            case Direction.DOWN:
                {
                    movement = this.movmentDown;
                    break;
                }
            case Direction.LEFT:
                {
                    movement = this.movmentLeft;
                    break;
                }
            case Direction.RIGHT:
                {
                    movement = this.movmentRight;
                    break;
                }
        }
    }

    public void calculateNewPosition() {
        this.setCurrentPosition((this.getCurrentPosition() + this.getMovement()));
	}

	public void move() {
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


