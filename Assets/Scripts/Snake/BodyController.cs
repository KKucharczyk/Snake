using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : AbstractBodyController
{
	public void setSpriteAccordingToPlane() {
		if (SnakeSequenceFactory.getReferenceToBodyController().CurrentDirection == Direction.LEFT || SnakeSequenceFactory.getReferenceToBodyController().CurrentDirection == Direction.RIGHT) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite(0));
		}
		if (SnakeSequenceFactory.getReferenceToBodyController().CurrentDirection == Direction.UP || SnakeSequenceFactory.getReferenceToBodyController().CurrentDirection == Direction.DOWN) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite(1));
		}
	}

	public void setSpriteAccordingToTurn(Direction currentHeadDirection, Direction previousHeadDirection) {
		if ((currentHeadDirection == Direction.UP && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.DOWN))) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite (3));
		}
		if ((currentHeadDirection == Direction.UP && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.DOWN))) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite (4));
		}
		if ((currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.UP))) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite (2));
		}
		if ((currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.UP))) {
            SnakeSequenceFactory.getReferenceToBodyController().setSprite (SnakeSequenceFactory.getReferenceToBodyController().getSprite (5));
		}
	}

    public void init(Direction dir)
    {
       this.currentDirection = dir;
    }
}


