using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour {

	public float speed;   // Tempo gry
	private Rigidbody2D rigidbody;   // Uchwyt do Rigidbody obiektu
	private float nextMove;   // Czas nastepnego ruchu
	private Vector3 movement;   // Kierunek ruchu 
	private bool grow;   // tymczasowe: czy rosnąć?
	public GameObject snakeBody;
	private LinkedList<GameObject> body;
	private Vector2 lastHeadPosition;
	int bodySize = 0;

	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		movement = new Vector3 (0.0f, 0.0f);
		body = new LinkedList<GameObject> ();
		lastHeadPosition = new Vector2 (0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update () {

		lastHeadPosition = rigidbody.transform.position;

		if (Input.anyKeyDown) 
		{
			if (Input.GetKey(KeyCode.UpArrow) && movement.y != -1)
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

		if (Time.time > nextMove) {
			nextMove = Time.time + (1 / speed);

			Move ();
			if(bodySize > 0)
				UpdateBodyLocation ();

			if (grow)
				Grow ();

			grow = false;
		}
	
	}

	void Move ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;
		rigidbody.transform.position = nextPosition;
	}

	void Grow ()
	{
		body.AddLast((GameObject) Instantiate(snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		bodySize++;
	}

	void UpdateBodyLocation() {
		body.AddAfter (body.First, (GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}
}
