using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class SnakeController : MonoBehaviour
{
	private LinkedList<GameObject> body;

	public GameObject HeadPrefab;
	private GameObject headHandler;
	private HeadController head;

	public GameObject TailPrefab;
	private TailController tailScript;

	public GameObject BodyPrefab;
	private BodyController bodyScript;

    void Awake() {
		headHandler = Instantiate (HeadPrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
		head = headHandler.GetComponent<HeadController> ();
		body = new LinkedList<GameObject> ();
		bodyScript = BodyPrefab.GetComponent<BodyController> ();
		tailScript = TailPrefab.GetComponent<TailController> ();
	}

	private bool hasBody() {
		return body.Count > 0;
	}

	public Direction getCurrentHeadDirection() {
		return head.getCurrentDirection();
	}

	public Direction getPreviousHeadDirection() {
		return head.getPreviousDirection();
	}

	public void setCurrentHeadDirection(Direction direction) {
		head.setCurrentDirection (direction);
	}

	public void setPreviousHeadDirection(Direction direction) {
		head.setPreviousDirection(direction);
	}

	public void grow() {
		bodyScript.setCurrentDirection (head.getCurrentDirection());
		bodyScript.setSpriteAccordingToPlane ();
		body.AddLast (GameObject.Instantiate (BodyPrefab,  head.getCurrentPosition() - head.getMovment(),  Quaternion.identity));
	}

	public int getBodySize() {
		return body.Count;
	}

	public void setHeadSprite(Sprite sprite) {
		head.setSprite (sprite);
	}

	public Sprite getHeadSprite(int index) {
		return head.getSprite (index);
	}

	public void setHeadDirection(Direction direction) {
		head.setMovment (direction);
	}

	public void calculateNewHeadPosition() {
		head.calculateNewPosition ();
	}

	public void moveHead() {
		head.move ();
	}

	public void updateBodyLocation() {
		if (hasBody () && head.isDirectionChanged ()) {
			bodyScript.setSpriteAccordingToTurn (head.getCurrentDirection (), head.getPreviousDirection ());
			head.setPreviousDirection (getCurrentHeadDirection ());
		} else {
			bodyScript.setCurrentDirection (head.getCurrentDirection ());
			bodyScript.setSpriteAccordingToPlane ();
		}
		body.AddBefore (body.First, Instantiate (BodyPrefab, head.getCurrentPosition () - head.getMovment (), Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}

}


