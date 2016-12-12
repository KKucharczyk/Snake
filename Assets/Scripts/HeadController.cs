using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rigidbody;
	private float nextMove;
	private Vector3 movement;
	private bool grow;
	public GameObject snakeBody;
	private LinkedList<GameObject> body;
	private Vector2 lastHeadPosition;

	public Sprite[] head;

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		movement = new Vector3 (0.0f, 0.0f);
		body = new LinkedList<GameObject> ();
		lastHeadPosition = new Vector2 (0.0f, 0.0f);
		//head = Resources.Load<Sprite> ("Snake_v2_10");
	}

	// Update is called once per frame
	void Update ()
	{
		
		lastHeadPosition = rigidbody.transform.position;
		if (Input.anyKeyDown) {
			if (Input.GetKey (KeyCode.UpArrow) && movement.y != -1) {
				movement = new Vector2 (0.0f, 1);
				GetComponent<SpriteRenderer> ().sprite = head [0];
			} else if (Input.GetKey (KeyCode.DownArrow) && movement.y != 1) {
				movement = new Vector2 (0.0f, -1);
				GetComponent<SpriteRenderer> ().sprite = head [1];
			}  else if (Input.GetKey (KeyCode.LeftArrow) && movement.x != 1) {
				movement = new Vector2 (-1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = head [3];
			} else if (Input.GetKey (KeyCode.RightArrow) && movement.x != -1) {
				movement = new Vector2 (1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = head [2];
			} else if (Input.GetKey (KeyCode.Space))
				grow = true;
		}

		if (Time.time > nextMove) {
			nextMove = Time.time + (1 / speed);

			Move ();

			if (grow)
				Grow ();

			if (body.Count > 0) {
				UpdateBodyLocation ();
			}
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
		body.AddLast ((GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
	}

	void UpdateBodyLocation ()
	{
		body.AddBefore (body.First, (GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}
}
