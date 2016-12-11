using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour {

	public float speed;   // Tempo gry
	private Rigidbody2D rigidbody;   // Uchwyt do Rigidbody obiektu
	private float nextMove;   // Czas nastepnego ruchu
	private Vector3 movement;   // Kierunek ruchu 

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		movement = new Vector3 (0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		// Zmiana kierunku ruchu
		//------------------------
		if (Input.anyKeyDown) 
		{
			if (Input.GetKey (KeyCode.UpArrow) && movement.y != -1)
				movement = new Vector2 (0.0f, 1);
			else if (Input.GetKey (KeyCode.RightArrow) && movement.x != -1)
				movement = new Vector2 (1, 0.0f);
			else if (Input.GetKey (KeyCode.DownArrow) && movement.y != 1)
				movement = new Vector2 (0.0f, -1);
			else if (Input.GetKey (KeyCode.LeftArrow) && movement.x != 1)
				movement = new Vector2 (-1, 0.0f);
		}
		//------------------------
		if (Time.time > nextMove) {
			nextMove = Time.time + (1 / speed);

			Move ();
		}
	
	}

	void Move ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;

		//GetComponent<BoxCollider2D>().enabled = false;
		//RaycastHit2D hit = Physics2D.Linecast (rigidbody.transform.position, nextPosition, LayerMask.GetMask ("Default"));
		//GetComponent<BoxCollider2D>().enabled = true;


		rigidbody.transform.position = nextPosition;

	}

}
