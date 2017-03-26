using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMethods
{
	public static Direction getOpposite (Direction direction)
	{
		if (direction == Direction.UP)
			return Direction.DOWN;
		if (direction == Direction.DOWN)
			return Direction.UP;
		if (direction == Direction.LEFT)
			return Direction.RIGHT;
		if (direction == Direction.RIGHT)
			return Direction.LEFT;
		return Direction.UNDEFINED;
	}

	public static Vector2 mapDirectionToMovment (Direction direction)
	{
		switch (direction) {
		case Direction.UP:
			{
				return SnakeConstants.movmentUp;
			}
		case Direction.DOWN:
			{
				return SnakeConstants.movmentDown;
			}
		case Direction.LEFT:
			{
				return SnakeConstants.movmentLeft;
			}
		case Direction.RIGHT:
			{
				return SnakeConstants.movmentRight;
			}
		}
		throw new UnityException ("Direction undefined.");
	}
}
