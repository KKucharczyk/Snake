﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class SnakeController : MonoBehaviour
{
	private LinkedList<GameObject> body;

	public GameObject headPrefab;
	private GameObject headHandler;
	private HeadController headController;

	public GameObject tailPrefab;
	private TailController tailController;

	public GameObject bodyPrefab;
	private BodyController bodyController;

    void Awake() {
		headHandler = Instantiate (headPrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
		headController = headHandler.GetComponent<HeadController> ();
		body = new LinkedList<GameObject> ();
		bodyController = bodyPrefab.GetComponent<BodyController> ();
		tailController = tailPrefab.GetComponent<TailController> ();
	}

	private bool hasBody() {
		return body.Count > 0;
	}

	public Direction getCurrentHeadDirection() {
		return headController.getCurrentDirection();
	}

	public Direction getPreviousHeadDirection() {
		return headController.getPreviousDirection();
	}

	public void setCurrentHeadDirection(Direction direction) {
		headController.setCurrentDirection (direction);
	}

	public void setPreviousHeadDirection(Direction direction) {
		headController.setPreviousDirection(direction);
	}

	public void grow() {
		bodyController.setCurrentDirection (headController.getCurrentDirection());
		bodyController.setSpriteAccordingToPlane ();
		body.AddLast (GameObject.Instantiate (bodyPrefab,  headController.getCurrentPosition() - headController.getMovment(),  Quaternion.identity));
	}

	public int getBodySize() {
		return body.Count;
	}

	public void setHeadSprite(Sprite sprite) {
		headController.setSprite (sprite);
	}

	public Sprite getHeadSprite(int index) {
		return headController.getSprite (index);
	}

	public void setHeadDirection(Direction direction) {
		headController.setMovment (direction);
	}

	public void calculateNewHeadPosition() {
		headController.calculateNewPosition ();
	}

	public void moveHead() {
		headController.move ();
	}

	public void updateBodyLocation() {
		if (hasBody () && headController.isDirectionChanged ()) {
			bodyController.setSpriteAccordingToTurn (headController.getCurrentDirection (), headController.getPreviousDirection ());
			headController.setPreviousDirection (getCurrentHeadDirection ());
		} else {
			bodyController.setCurrentDirection (headController.getCurrentDirection ());
			bodyController.setSpriteAccordingToPlane ();
		}
		body.AddBefore (body.First, Instantiate (bodyPrefab, headController.getCurrentPosition () - headController.getMovment (), Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}

	public bool isGrowing() {
		return headController.getIsGrowing ();
	}

	public void toggleGrowing() {
		headController.toggleIsGrowing ();
	}

}


