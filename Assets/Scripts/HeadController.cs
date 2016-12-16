using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
	public float speed;
	private Rigidbody2D rigidbody = new Rigidbody2D ();
	private float nextMove;
	private Vector3 movement;
	private bool grow;
	public GameObject snakeBody;
	private LinkedList<GameObject> body;
	private Vector2 lastHeadPosition = new Vector2();

	public Sprite[] headSprites;
	public Sprite[] bodySprites;

	private SpriteRenderer spriteRenderer;

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
			if (Input.GetKey (KeyCode.UpArrow) && movement.y != -1) {
				movement = new Vector2 (0.0f, 1);
				GetComponent<SpriteRenderer> ().sprite = headSprites [0];
			} else if (Input.GetKey (KeyCode.DownArrow) && movement.y != 1) {
				movement = new Vector2 (0.0f, -1);
				GetComponent<SpriteRenderer> ().sprite = headSprites [1];
			}  else if (Input.GetKey (KeyCode.LeftArrow) && movement.x != 1) {
				movement = new Vector2 (-1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = headSprites [3];
			} else if (Input.GetKey (KeyCode.RightArrow) && movement.x != -1) {
				movement = new Vector2 (1, 0.0f);
				GetComponent<SpriteRenderer> ().sprite = headSprites [2];
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

		// Sprawdź czy po wykonaniu ruchu natrafisz na ciało kolizyjne
		// jezeli tak, zniszcz siebie (głowę)
		RaycastHit2D hit = Physics2D.Linecast (rigidbody.transform.position, nextPosition, LayerMask.GetMask ("Default"));
		if (hit.transform != null)
			Debug.Log("Uderzyłem");
		

		rigidbody.transform.position = nextPosition;
	}

	void Grow ()
	{
			Vector2 nextPosition = rigidbody.transform.position + movement;
			if (body.Count > 0 && lastHeadPosition.x != nextPosition.x) {
				snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites[0];
			} else {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites[1];
			}
			this.body.AddLast ((GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));

	}

	void UpdateBodyLocation ()
	{
		Vector2 nextPosition = rigidbody.transform.position + movement;
		if (body.Count > 0 && lastHeadPosition.x != nextPosition.x) {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites[0];
		} else {
			snakeBody.GetComponent<SpriteRenderer> ().sprite = bodySprites[1];
		}
		body.AddBefore (body.First, (GameObject)Instantiate (snakeBody, rigidbody.transform.position - movement, Quaternion.identity));
		Destroy (body.Last.Value);
		body.RemoveLast ();
	}
}
