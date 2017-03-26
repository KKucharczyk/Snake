using UnityEngine;

public abstract class AbstractBodyController : MonoBehaviour {

    protected Direction currentDirection;
    public Direction CurrentDirection {
        get {
            return currentDirection;
        }
        set {
            currentDirection = value;
        }
    }
    protected Direction previousDirection;
    public Direction PreviousDirection
    {
        get
        {
            return previousDirection;
        }
        set
        {
            previousDirection = value;
        }
    }

    protected Vector2 currentPosition;
    public Vector2 CurrentPosition {
    get {
            return currentPosition;
        }
    set {
            currentPosition = value;
        }
    }
    protected Vector2 previousPosition;
    public Vector2 PreviousPosition
    {
        get
        {
            return previousPosition;
        }
        set
        {
            previousPosition = value;
        }
    }

    public Sprite[] sprites;
    protected SpriteRenderer spriteRenderer;


    public Sprite getSprite(int index)
    {
        return this.sprites[index];
    }

    public void setSprite(Sprite sprite)
    {
        this.GetComponent<SpriteRenderer>().sprite = sprite;
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

}
