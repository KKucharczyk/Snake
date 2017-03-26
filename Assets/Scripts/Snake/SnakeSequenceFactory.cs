using UnityEngine;

public class SnakeSequenceFactory : MonoBehaviour
{
	public static readonly GameObject headPrefab = (GameObject)Resources.Load ("HeadPrefab");
	public static readonly GameObject bodyPrefab = (GameObject)Resources.Load ("BodyPrefab");
	public static readonly GameObject tailPrefab = (GameObject)Resources.Load ("TailPrefab");

	public static GameObject createHeadController (Vector2 position)
	{
		return Instantiate (headPrefab, position, Quaternion.identity);
	}

	public static GameObject createBodyController (Vector2 position)
	{
		return Instantiate (bodyPrefab, position, Quaternion.identity);
	}

	public static GameObject createTailController (Vector2 position)
	{
		return Instantiate (tailPrefab, position, Quaternion.identity);
	}

	public static HeadController getReferenceToHeadController ()
	{
		return headPrefab.GetComponent<HeadController> ();
	}

	public static BodyController getReferenceToBodyController ()
	{
		return bodyPrefab.GetComponent<BodyController> ();
	}

	public static TailController getReferenceToTailController ()
	{
		return tailPrefab.GetComponent<TailController> ();
	}

	public static SpriteRenderer getReferenceToBodySpriteRenderer ()
	{
		return bodyPrefab.GetComponent<SpriteRenderer> ();
	}

	public static SpriteRenderer getReferenceToTailSpriteRenderer ()
	{
		return tailPrefab.GetComponent<SpriteRenderer> ();
	}
}
