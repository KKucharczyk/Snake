using UnityEngine;

public class BodyController : AbstractBodyController, IBodyController
{
    public void init(Direction direction)
    {
        this.currentDirection = direction;
    }

	public void setSpriteAccordingToPlane(Direction direction)
    {
        if (isHorizontal(direction))
        {
            setBodySprite(BodySprite.HORIZONTAL.toInt());
        }
		else if (isVertical(direction))
        {
            setBodySprite(BodySprite.VERTICAL.toInt());
        }
    }

    public void setSpriteAccordingToTurn(Direction currentHeadDirection, Direction previousHeadDirection)
    {
        if (isNorth_WestTurn(currentHeadDirection, previousHeadDirection))
        {
            setBodySprite(BodySprite.NORTH_WEST.toInt());
        }
        if (isNorth_EastTurn(currentHeadDirection, previousHeadDirection))
        {
            setBodySprite(BodySprite.NORTH_EAST.toInt());
        }
        if (isSouth_WestTurn(currentHeadDirection, previousHeadDirection))
        {
            setBodySprite(BodySprite.SOUTH_WEST.toInt());
        }
        if (isSouth_EastTurn(currentHeadDirection, previousHeadDirection))
        {
            setBodySprite(BodySprite.SOUTH_EAST.toInt());
        }
    }

    /// <summary>
    /// Method checks for those turns:
    /// 
    /// O--      ---    
    ///   |        |  
    ///   |        O
    ///     
    /// lines - snake's body parts
    /// O - head part
    /// 
    /// </summary>
    /// <param name="currentHeadDirection"></param>
    /// <param name="previousHeadDirection"></param>
    /// <returns></returns>
    private bool isNorth_WestTurn(Direction currentHeadDirection, Direction previousHeadDirection)
    {
        return (currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.UP));
    }

    /// <summary>
    /// Method checks for those turns:
    /// 
    /// ---     --O
    /// |       |
    /// O       |
    ///     
    /// lines - snake's body parts
    /// O - head part
    /// 
    /// </summary>
    /// <param name="currentHeadDirection"></param>
    /// <param name="previousHeadDirection"></param>
    /// <returns></returns>
    private bool isNorth_EastTurn(Direction currentHeadDirection, Direction previousHeadDirection)
    {
        return (currentHeadDirection == Direction.UP && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.DOWN));
    }

    /// <summary>
    /// Method checks for those turns:
    /// 
    ///   O         |
    ///   |         |
    /// ---       O--
    ///     
    /// lines - snake's body parts
    /// O - head part
    /// 
    /// </summary>
    /// <param name="currentHeadDirection"></param>
    /// <param name="previousHeadDirection"></param>
    /// <returns></returns>
    private bool isSouth_WestTurn(Direction currentHeadDirection, Direction previousHeadDirection)
    {
        return (currentHeadDirection == Direction.UP && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.DOWN));
    }

    /// <summary>
    /// Method checks for those turns:
    /// 
    /// O         |
    /// |         |
    /// ---       --O
    ///     
    /// lines - snake's body parts
    /// O - head part
    /// 
    /// </summary>
    /// <param name="currentHeadDirection"></param>
    /// <param name="previousHeadDirection"></param>
    /// <returns></returns>
    private bool isSouth_EastTurn(Direction currentHeadDirection, Direction previousHeadDirection)
    {
        return (currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.UP));
    }

    private bool isHorizontal(Direction direction)
    {
        return direction == Direction.LEFT || direction == Direction.RIGHT;
    }

    private bool isVertical(Direction direction)
    {
        return direction == Direction.UP || direction == Direction.DOWN;
    }

    private void setBodySprite(int spriteIndex)
    {
        SnakeSequenceFactory.getReferenceToBodyController().setSprite(SnakeSequenceFactory.getReferenceToBodyController().getSprite(spriteIndex));
    }

    private Direction getCurrentBodyDirection()
    {
        return SnakeSequenceFactory.getReferenceToBodyController().CurrentDirection;
    }

	public void setCurrentDirection(Direction currentDirection) {
		this.currentDirection = currentDirection;

	}
}


