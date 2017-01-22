using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBodyController : MonoBehaviour {

    protected Direction currentDirection;
    protected Direction previousDirection;

    protected Vector2 currentPosition;
    protected Vector2 previousPosition;

    public Sprite[] sprites;
	protected SpriteRenderer spriteRenderer;
	

    protected readonly Vector2 movmentUp = new Vector2(0.0f, 1.0f);
    protected readonly Vector2 movmentDown = new Vector2(0.0f, -1.0f);
    protected readonly Vector2 movmentLeft = new Vector2(-1.0f, 0.0f);
    protected readonly Vector2 movmentRight = new Vector2(1.0f, 0.0f);

    public Direction getCurrentDirection() {
		return currentDirection;
	}

	public void setCurrentDirection(Direction direction) {
		this.currentDirection = direction;
	}

    public Direction getPreviousDirection()
    {
        return previousDirection;
    }

    public void setPreviousDirection(Direction direction)
    {
        this.previousDirection = direction;
    }

    public Vector2 getCurrentPosition()
    {
        return currentPosition;
    }

    public void setCurrentPosition(Vector2 position)
    {
        this.currentPosition = position;
    }

    public Vector2 getPreviousPosition()
    {
        return previousPosition;
    }

    public void setPreviousPosition(Vector2 position)
    {
        this.previousPosition = position;
    }

    protected Direction findDirection(Vector2 currentPosition, Vector2 previousPosition) {
		if (currentPosition.x > previousPosition.x)
			return Direction.RIGHT;
		if (currentPosition.x < previousPosition.x)
			return Direction.LEFT;
		if (currentPosition.y > previousPosition.y)
			return Direction.UP;
		if (currentPosition.y < previousPosition.y)
			return Direction.DOWN;
		return Direction.UNDEFINED;
	}
		
	public Sprite getSprite(int index) {
		return this.sprites[index];
	}
}
