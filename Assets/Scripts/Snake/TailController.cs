using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailController : AbstractBodyController
{
	public GameObject TailPrefab;

	public TailController ()
	{

	}

	public GameObject createTail(GameObject bodyPart) {
		switch (bodyPart.GetComponent<BodyController>().getCurrentDirection()) {
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


