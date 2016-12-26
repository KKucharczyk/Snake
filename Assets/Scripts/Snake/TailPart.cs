using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : AbstractBodyPart
{
	public GameObject TailPrefab;

	public TailPart ()
	{

	}

	public GameObject createTail(GameObject bodyPart) {
		switch (bodyPart.GetComponent<BodyPart>().getCurrentDirection()) {
		case Direction.UP:
			{
				this.GetComponent<SpriteRenderer> ().sprite = this.getSprite (1);
				break;
			}
		case Direction.DOWN:
			{
				this.GetComponent<SpriteRenderer> ().sprite = this.getSprite (2);
				break;
			}
		case Direction.LEFT:
			{
				this.GetComponent<SpriteRenderer> ().sprite = this.getSprite (0);
				break;
			}
		case Direction.RIGHT:
			{
				this.GetComponent<SpriteRenderer> ().sprite = this.getSprite (3);
				break;
			}
		}
		return Instantiate (TailPrefab, bodyPart.GetComponent<Transform> ());
	}
}


