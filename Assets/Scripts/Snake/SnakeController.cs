using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
	private LinkedList<GameObject> body;
	public GameObject fuckingPrefab;
	private GameObject headHandler;
	private HeadController headController;

	public GameObject tailPrefab;
	private GameObject tailHandler;
	private TailController tailController;

	public GameObject bodyPrefab;
	private BodyController bodyController;
	bool wasGrowing = false;

	void Awake ()
	{
		headHandler = SnakeSequenceFactory.createHeadController (new Vector2 (0.0f, 0.0f));
		headController = headHandler.GetComponent<HeadController> ();
		bodyController = bodyPrefab.GetComponent<BodyController> ();
		tailController = tailPrefab.GetComponent<TailController> ();
		body = new LinkedList<GameObject> ();
	}

	public Direction getCurrentHeadDirection ()
	{
		return headController.CurrentDirection;
	}

	public void setCurrentHeadDirection (Direction direction)
	{
		headController.CurrentDirection = direction;
	}

	public Direction getPreviousHeadDirection ()
	{
		return headController.PreviousDirection;
	}

	public void setPreviousHeadDirection (Direction direction)
	{
		headController.PreviousDirection = direction;
	}

	private bool hasAnyBody ()
	{
		return body.Count > 0;
	}

	public void grow ()
	{
		bodyController.setSpriteAccordingToPlane (this.getCurrentHeadDirection ());
		SnakeSequenceFactory.getReferenceToBodyController ().CurrentDirection = headController.CurrentDirection;
		body.AddLast (SnakeSequenceFactory.createBodyController (headController.CurrentPosition - DirectionMethods.mapDirectionToMovment (headController.CurrentDirection)));
		wasGrowing = true;
		HeadBehaviour.setGrowing (false);
	}

	public void moveSnake ()
	{
		headController.move ();
	}

	public void updateBodyLocation ()
	{
		if (!hasAnyBody ()) {
			if (tailHandler != null)
				Destroy (tailHandler);
			tailController.createTail (headController.CurrentDirection);
			tailHandler = SnakeSequenceFactory.createTailController (headController.CurrentPosition - DirectionMethods.mapDirectionToMovment (headController.CurrentDirection));
		} else {
			if (headController.isDirectionChanged ()) {
				bodyController.setSpriteAccordingToTurn (headController.CurrentDirection, headController.PreviousDirection);
				headController.PreviousDirection = getCurrentHeadDirection ();
			} else {
				bodyController.setSpriteAccordingToPlane (this.getCurrentHeadDirection ());
			}
 
			if (!wasGrowing) {
				Destroy (tailHandler);
                
				tailController.createTail (body.Last.Value.GetComponent<BodyController> ().CurrentDirection);
				tailHandler = SnakeSequenceFactory.createTailController (body.Last.Value.GetComponent<Transform> ().position);
			}
			SnakeSequenceFactory.getReferenceToBodyController ().CurrentDirection = headController.CurrentDirection;
            
			GameObject bodyHandler = SnakeSequenceFactory.createBodyController (headController.CurrentPosition - DirectionMethods.mapDirectionToMovment (headController.CurrentDirection));
			bodyHandler.GetComponent<BodyController> ().init (getCurrentHeadDirection ());

			body.AddBefore (body.First, bodyHandler);
			Destroy (body.Last.Value);
			body.RemoveLast ();
		}
		wasGrowing = false;

	}
}


