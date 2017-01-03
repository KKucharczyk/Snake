using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public int value;

	private GameController gameController;

	// Use this for initialization
	void Start () 
	{
		GameObject gC = GameObject.FindWithTag ("GameController");
		if (gC != null) 
		{
			gameController = gC.GetComponent<GameController> ();
		} 
		else 
		{
			Debug.Log ("FoodController.Start() : Cannot find GameController");
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		gameController.AddPoints (value);
		Destroy (gameObject);
	}
}
