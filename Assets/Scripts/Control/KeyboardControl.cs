using UnityEngine;

class KeyboardControl : IControl
{
    public Direction getNewDirection(Direction currentHeadDirection)
    {
        Direction newHeadDirection = Direction.UNDEFINED;

        if (Input.GetKey(KeyCode.UpArrow) && currentHeadDirection != Direction.DOWN)
        {
            newHeadDirection = Direction.UP;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && currentHeadDirection != Direction.UP)
        {
            newHeadDirection = Direction.DOWN;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && currentHeadDirection != Direction.RIGHT)
        {
            newHeadDirection = Direction.LEFT;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && currentHeadDirection != Direction.LEFT)
        {
            newHeadDirection = Direction.RIGHT;
        }

        return newHeadDirection;
    }
}

