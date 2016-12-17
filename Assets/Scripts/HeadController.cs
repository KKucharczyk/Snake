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
	private Vector2 lastHeadPosition = new Vector2 ();

	public Sprite[] headSprites;
	public Sprite[] bodySprites;
	public Sprite[] bodyRotationSprites;

	private SpriteRenderer spriteRenderer;
	bool changedDirection = false;

	enum Direction {
		UP,
		DOWN,
		LEFT,
		RIGHT
	};

	private Direction headDirection = Direction.RIGHT;

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
		
		lastHeadPosition = rigidbody.transform.position;

		if (Input.anyKeyDown) {
			changedDirection = true;
			if (Input.GetKey (KeyCode.UpArrow) && movement.y != -1) {
				movement = new Vector2 (0.0f, 1);
				GetComponent<SpriteRenderer> ().sprite = headSprites [0];
				headDirection = Direction.UP;
			} else if (Input.GetKey (KeyCode.DownArrow) && movement.y != 1) {
				movement = new Vector2 (0.0f, -1);
				GetComponent<SpriteRenderer> ().sprite = headSprites [1];
				headDirection = Direction.DOWN;
			} else if (Input.GetKey (KeyCode.LeftArrow) && movement.x != 1) {
				movement = new Vector2 (-1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = headSprites [3];
				headDirection = Direction.LEFT;
			} else if (Input.GetKey (KeyCode.RightArrow) && movement.x != -1) {
				movement = new Vector2 (1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = headSprites [2];
				headDirection = Direction.RIGHT;
			} else if (Input.GetKey (KeyCode.Space))

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
		Vector2 nextPosition = rigidbody.transform.position + movement;

		RaycastHit2D hit = Physics2D.Linecast (rigidbody.transform.position, nextPosition, LayerMask.GetMask ("Default"));

		rigidbody.transform.position = nextPosition;
	}

	void Grow ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;
		if (body.Count > 0 && lastHeadPosition.x != nextPosition.x) {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [0];
		} else {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites [1];
		}
		this.body.AddLast ((GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));

	}


	void UpdateBodyLocation ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;
		if (body.Count > 2 && changedDirection == true) {
			changedDirection = false;
			Debug.Log ("Ostry skręt.");
			if (this.body.First.Next.Next.Value.transform.position.x < this.body.First.Value.transform.position.x && nextPosition.x == lastHeadPosition.x && nextPosition.y > lastHeadPosition.y) {
				Debug.Log ("Z prawej w górę.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [1];
			}

			if (this.body.First.Next.Next.Value.transform.position.x > this.body.First.Value.transform.position.x && nextPosition.x == lastHeadPosition.x && nextPosition.y > lastHeadPosition.y) {
				Debug.Log ("Z lewej w górę.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [2];
			}

			if (this.body.First.Next.Next.Value.transform.position.x < this.body.First.Value.transform.position.x && nextPosition.x == lastHeadPosition.x && nextPosition.y < lastHeadPosition.y) {
				Debug.Log ("Z prawej w dół.");				
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [0];
			}

			if (this.body.First.Next.Next.Value.transform.position.x > this.body.First.Value.transform.position.x && nextPosition.x == lastHeadPosition.x && nextPosition.y < lastHeadPosition.y) {
				Debug.Log ("Z lewej w dół.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [3];
			}

			if (this.body.First.Next.Next.Value.transform.position.y < this.body.First.Value.transform.position.y && nextPosition.y == lastHeadPosition.y && nextPosition.x > lastHeadPosition.x) {
				Debug.Log ("Z góry w prawo.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [3];
			}

			if (this.body.First.Next.Next.Value.transform.position.y < this.body.First.Value.transform.position.y && nextPosition.y == lastHeadPosition.y && nextPosition.x < lastHeadPosition.x) {
				Debug.Log ("Z góry w lewo.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [0];
			}


			if (this.body.First.Next.Next.Value.transform.position.y > this.body.First.Value.transform.position.y && nextPosition.y == lastHeadPosition.y && nextPosition.x > lastHeadPosition.x) {
				Debug.Log ("Z dołu w prawo.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [2];
			}

			if (this.body.First.Next.Next.Value.transform.position.y > this.body.First.Value.transform.position.y && nextPosition.y == lastHeadPosition.y && nextPosition.x < lastHeadPosition.x) {
				Debug.Log ("Z dołu w lewo.");
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodyRotationSprites [1];
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
		Debug.Log ("Jestem tuuuuu");
		if (other.tag == "Snake" || other.tag == "Wall")
			Destroy (gameObject);
		else if (other.tag == "Food") 
		{
			grow = true;
			Debug.Log ("Jestem tu");
		}
	}
}
