using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour 
{
	private enum DIRECTION
	{
		NONE,
		RIGHT,
		UP,
		LEFT,
		DOWN
	}

	public float speed;   // Tempo gry
	private Rigidbody2D rigidbody;   // Uchwyt do Rigidbody obiektu
	private float nextMove;   // Czas nastepnego ruchu
	private Vector3 movement;   // Kierunek ruchu 
	private bool grow;   // tymczasowe: czy rosnąć?
	public GameObject snakeBody;
	private LinkedList<GameObject> body;
	private Vector2 lastHeadPosition;
	private DIRECTION direction;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		movement = new Vector3 (0.0f, 0.0f);
		body = new LinkedList<GameObject> ();
		lastHeadPosition = new Vector2 (0.0f, 0.0f);
		direction = DIRECTION.NONE;
	}

	// Update is called once per frame
	void Update () {
		
		lastHeadPosition = rigidbody.transform.position;
		//Debug.Log (body.Count);
		if (Input.anyKeyDown) 
		{
			if (Input.GetKey(KeyCode.UpArrow) && movement.y != -1)
				direction = DIRECTION.UP;
			else if (Input.GetKey (KeyCode.RightArrow) && movement.x != -1)
				direction = DIRECTION.RIGHT;
			else if (Input.GetKey (KeyCode.DownArrow) && movement.y != 1)
				direction = DIRECTION.DOWN;
			else if (Input.GetKey (KeyCode.LeftArrow) && movement.x != 1)
				direction = DIRECTION.LEFT;
			else if (Input.GetKey (KeyCode.Space))
				grow = true;
		}

		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (1 / speed);

			Move ();

			if (grow)
				Grow ();

			if (body.Count > 0) 
			{
				UpdateBodyLocation ();
			}


			grow = false;
		}
	
	}

	void Move ()
	{
		switch (direction) 
		{
			case DIRECTION.RIGHT: movement = new Vector3 (1, 0); break;
			case DIRECTION.UP: movement = new Vector3 (0, 1); break;
			case DIRECTION.LEFT: movement = new Vector3 (-1, 0); break;
			case DIRECTION.DOWN: movement = new Vector3 (0, -1); break;
		}
		Vector2 nextPosition = rigidbody.transform.position + movement;

		/*
		// Sprawdź czy po wykonaniu ruchu natrafisz na ciało kolizyjne
		// jezeli tak, zniszcz siebie (głowę)
		RaycastHit2D hit = Physics2D.Linecast (rigidbody.transform.position, nextPosition, LayerMask.GetMask ("Default"));
		if (hit.transform != null)
			Debug.Log("Uderzyłem");
		*/

		rigidbody.transform.position = nextPosition;
	}

	void Grow ()
	{
		body.AddLast((GameObject) Instantiate(snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
	}

	void UpdateBodyLocation() 
	{
		body.AddBefore (body.First, (GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Snake" || other.tag == "Wall")
			Destroy(gameObject);
		else if (other.tag == "Food")
			grow = true;
	}
}
