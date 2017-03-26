using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : AbstractBodyController, IHeadController
{
	public void move ()
	{
		this.prepareForMove ();
		this.moveSpriteToCurrentPosition ();
	}

	public bool isDirectionChanged ()
	{
		return this.CurrentDirection != this.PreviousDirection;
	}

	private void prepareForMove ()
	{
		this.setSprite (this.getSprite ((int)this.CurrentDirection));
		this.calculateCurrentPosition ();
	}

	private void calculateCurrentPosition ()
	{
		this.CurrentPosition = (this.CurrentPosition + DirectionMethods.mapDirectionToMovment (this.CurrentDirection));
	}

	private void moveSpriteToCurrentPosition ()
	{
		this.GetComponent<Rigidbody2D> ().transform.position = this.CurrentPosition;
	}
}


