using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMethods {

	public static Direction getOpposite(Direction direction) {
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
}
