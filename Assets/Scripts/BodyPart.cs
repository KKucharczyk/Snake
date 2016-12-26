using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : AbstractBodyPart
{
	public BodyPart ()
	{
		
	}

	public void setSprite(Sprite sprite) {
		this.GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	public void setSpriteAccordingToPlane() {
		if (this.getCurrentDirection() == Direction.LEFT || this.getCurrentDirection() == Direction.RIGHT) {
			this.setSprite (this.getSprite(0));
		}
		if (this.getCurrentDirection() == Direction.UP || this.getCurrentDirection() == Direction.DOWN) {
			this.setSprite (this.getSprite(1));
		}
	}

	public void setSpriteAccordingToTurn(Direction currentHeadDirection, Direction previousHeadDirection) {
		if ((currentHeadDirection == Direction.UP && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.DOWN))) {
			this.setSprite (this.getSprite (3));
		}
		if ((currentHeadDirection == Direction.UP && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.DOWN))) {
			this.setSprite (this.getSprite (4));
		}
		if ((currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.RIGHT) || ((currentHeadDirection == Direction.LEFT && previousHeadDirection == Direction.UP))) {
			this.setSprite (this.getSprite (2));
		}
		if ((currentHeadDirection == Direction.DOWN && previousHeadDirection == Direction.LEFT) || ((currentHeadDirection == Direction.RIGHT && previousHeadDirection == Direction.UP))) {
			this.setSprite (this.getSprite (5));
		}
	}
}


