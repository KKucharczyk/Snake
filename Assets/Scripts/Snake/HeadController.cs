using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadController : AbstractBodyController
{
    private Vector2 movement;
    private bool growing = false;

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

    public void calculateCurrentPosition() {
        this.CurrentPosition = (this.CurrentPosition + this.getMovement());
	}

	public void moveSpriteToCurrentPosition() {
		this.GetComponent<Rigidbody2D> ().transform.position = this.CurrentPosition;
	}

	public bool isDirectionChanged() {
		return this.CurrentDirection != this.PreviousDirection;
	}

    public bool getGrowing()
    {
        return this.growing;
    }

    public void setGrowing(bool value) {
		this.growing = value;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject headGameObject = this.gameObject;
        GameObject objectInCollision = other.gameObject;

        if (other.tag == wallTag || other.tag == snakeTag)
        {
            SceneManager.LoadScene("EndGame");
            Destroy(headGameObject);
        }
        else if (other.tag == foodTag)
        {
            growing = true;
            Destroy(objectInCollision);
        }
    }

   
}


