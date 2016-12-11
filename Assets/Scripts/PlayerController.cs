using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public float speed;   // Tempo gry

	private float nextMove;   // Czas nastepnego ruchu

	private Rigidbody2D rigidbody;   // Uchwyt do Rigidbody obiektu

	private Vector3 movement;   // Kierunek ruchu 

	private bool grow;   // tymczasowe: czy rosnąć?

	public GameObject bodyPrefab;

	private class Snake
	{
		public Snake next;
		public Snake previous;

		private GameObject bodyPart;

		public Snake (Snake n, Snake p, GameObject bP)
		{
			next = n;
			previous = p;
			bodyPart = bP;
		}

		public void MoveBodyPart (Vector2 newPosition)
		{
			bodyPart.GetComponent<Rigidbody2D>().transform.position = newPosition;
		}
	}

	private Snake first;   // Pierwszy element (zaraz za glowa)
	private Snake last;   // Ostatni element



	// Use this for initialization
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		movement = new Vector3 (0.0f, 0.0f);
		first = null;
		last = null;
		grow = false;
	}


	// Update is called once per frame
	void Update () 
	{

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
			else if (Input.GetKey (KeyCode.Space))
				grow = true;
		}
		//------------------------

		// Kolejne tury
		//------------------------
		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (1 / speed);

			Move ();
			//if (grow)
			//	Grow ();
			
			grow = false;
		}
		//------------------------
	}

	void Move ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;

		GetComponent<BoxCollider2D>().enabled = false;
		RaycastHit2D hit = Physics2D.Linecast (rigidbody.transform.position, nextPosition, LayerMask.GetMask ("Default"));
		GetComponent<BoxCollider2D>().enabled = true;

		if (hit.transform != null)
			Destroy (gameObject);

		//Rotate ();
		rigidbody.transform.position = nextPosition;

		// Przemieszczenie ostatniego elementu weza na pcozatek
		if (first != null && !grow) 
		{
			last.MoveBodyPart (rigidbody.transform.position - movement);

			Snake temp = last;
			first.previous = last;
			last.next = first;
			last.previous.next = null;
			first = last;
			last = first.previous;
			first.previous = null;
		}

	}

	void Rotate ()
	{
		if (movement.x != 0) 
		{
			if (movement.x == 1)
				rigidbody.MoveRotation (0);
			else
				rigidbody.MoveRotation (180);
		} 
		else 
		{
			if (movement.y == 1)
				rigidbody.MoveRotation (90);
			else
				rigidbody.MoveRotation (270);
		}
	}

	void Grow ()
	{
		if (first != null) 
		{
			first.previous = new Snake (null, null, Instantiate(bodyPrefab, rigidbody.transform.position - movement, Quaternion.identity));
			first = first.previous;
		} 
		else 
		{
			last = first = new Snake (null, null, Instantiate(bodyPrefab, rigidbody.transform.position - movement, Quaternion.identity));
		}
	}
}
