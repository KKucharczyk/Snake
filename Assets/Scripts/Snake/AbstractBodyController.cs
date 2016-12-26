using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBodyController : MonoBehaviour {
	
	public Sprite[] sprites;
	protected SpriteRenderer spriteRenderer;
	protected Direction currentDirection;

	public Direction getCurrentDirection() {
		return currentDirection;
	}

	public void setCurrentDirection(Direction direction) {
		this.currentDirection = direction;
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
