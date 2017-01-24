using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : AbstractBodyController
{
	public void createTail(Direction direction) {
        switch (direction) {
            
		case Direction.UP:
			{
				SnakeSequenceFactory.getReferenceToTailSpriteRenderer().sprite = this.getSprite (1);
				break;
			}
		case Direction.DOWN:
			{
                    SnakeSequenceFactory.getReferenceToTailSpriteRenderer().sprite = this.getSprite (2);
				break;
			}
		case Direction.LEFT:
			{
                    SnakeSequenceFactory.getReferenceToTailSpriteRenderer().sprite = this.getSprite (0);
				break;
			}
		case Direction.RIGHT:
			{
                    SnakeSequenceFactory.getReferenceToTailSpriteRenderer().sprite = this.getSprite (3);
				break;
			}
		}

	}
}


