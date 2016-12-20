using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeadController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rigidbody;

	private bool grow;
	public GameObject snakeBody;
	private LinkedList<GameObject> body;

	private float nextMove;

	private Vector3 movement;
	private Vector2 lastHeadPosition;
	private Vector2 nextPosition;

	bool changedDirection = false;

	public Sprite[] headSprites;
	public Sprite[] bodySprites;
	public Sprite[] bodyRotationSprites;

	private SpriteRenderer spriteRenderer;

	private string snakeTag = "Snake";
	private string wallTag = "Wall";
	private string foodTag = "Food";

	void Start ()
	{
		rigidbody = GetComponent<Rigidbody2D> ();
		movement = new Vector3 (0.0f, 0.0f);
		body = new LinkedList<GameObject> ();
		lastHeadPosition = new Vector2 (0.0f, 0.0f);
	}

	// Update is called once per frame
	void Update ()
	{
		lastHeadPosition = this.rigidbody.transform.position;
		if (Input.anyKeyDown) {
			analyzeKeyPressed ();
		}

		nextPosition = rigidbody.transform.position + movement;

		if (Time.time > nextMove) 
		{
			nextMove = Time.time + (1 / speed);
			MoveHead ();
			if (grow)
				Grow ();

			if (body.Count > 0) 
			{
				UpdateBodyLocation ();
			}
			grow = false;
		}
	}

	void analyzeKeyPressed() {
			changedDirection = true;
		if (Input.GetKey (KeyCode.UpArrow)) {
			changeHeadDirection (new Vector2 (0.0f, 1), headSprites [0]);
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			changeHeadDirection (new Vector2 (0.0f, -1), headSprites [1]);
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			changeHeadDirection (new Vector2 (-1, 0.0f), headSprites [3]);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			changeHeadDirection (new Vector2 (1, 0.0f), headSprites [2]);
		} else if (Input.GetKey (KeyCode.Space)) {
			grow = true;
		}
	}

	void changeHeadDirection(Vector2 coordinates, Sprite sprite) {
		movement = coordinates;
		GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	void MoveHead ()
	{
		rigidbody.transform.position = nextPosition;
	}

	void Grow ()
	{
		if (body.Count > 0 && lastHeadPosition.x != nextPosition.x) {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [0];
		} else {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [1];
		}
		this.body.AddLast ((GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));

	}

	void UpdateBodyLocation ()
	{
		if (body.Count > 1 && changedDirection == true) {
			changedDirection = false;
			float x_przedPierwszy = this.body.First.Next.Value.transform.position.x;
			float x_pierwszy = this.body.First.Value.transform.position.x;

			float y_przedPierwszy = this.body.First.Next.Value.transform.position.y;
			float y_pierwszy = this.body.First.Value.transform.position.y;

			if((x_przedPierwszy < x_pierwszy && nextPosition.x == lastHeadPosition.x && nextPosition.y < lastHeadPosition.y) || (y_przedPierwszy < y_pierwszy && nextPosition.y == lastHeadPosition.y && nextPosition.x < lastHeadPosition.x))
			{		
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [0];
			}

			if((x_przedPierwszy < x_pierwszy && nextPosition.x == lastHeadPosition.x && nextPosition.y > lastHeadPosition.y) || (y_przedPierwszy > y_pierwszy && nextPosition.y == lastHeadPosition.y && nextPosition.x < lastHeadPosition.x))
			{
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [1];
			}

			if((x_przedPierwszy > x_pierwszy && nextPosition.x == lastHeadPosition.x && nextPosition.y > lastHeadPosition.y) || (y_przedPierwszy > y_pierwszy && nextPosition.y == lastHeadPosition.y && nextPosition.x > lastHeadPosition.x))
			{
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [2];
			}

			if((x_przedPierwszy > x_pierwszy && nextPosition.x == lastHeadPosition.x && nextPosition.y < lastHeadPosition.y) || (y_przedPierwszy < y_pierwszy && nextPosition.y == lastHeadPosition.y && nextPosition.x > lastHeadPosition.x))
			{
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [3];
			}
				
		} else {
			if (body.Count > 0 && lastHeadPosition.x != nextPosition.x) {
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [0];
			} else if (body.Count > 0 && lastHeadPosition.y != nextPosition.y) {
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [1];
			} 
		}

		body.AddBefore (body.First, (GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == snakeTag || other.tag == wallTag)
			Destroy (gameObject);
		else if (other.tag == foodTag) 
		{
			grow = true;
		}
	}
}
