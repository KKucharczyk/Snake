using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Linked to resources/HeadPrefab.
/// 
/// Class separates pure behaviour from logic. 
/// Snake's logic consists of all checks and computation, while hebaviour is actual script 
/// for the HeadPrefab. The only HeadPrefab behaviour is to collide with different entities 
/// on board. That is why this class consists only of method like OnTriggerEnter2D. 
/// 
/// Possible states are kept in static fields, so they can be easily obtained in logic's most crucial
/// places.
/// </summary>
public class HeadBehaviour : MonoBehaviour
{

	public static bool growing = false;

	public static bool isGrowing ()
	{
		return growing;
	}

	public static void setGrowing (bool value)
	{
		growing = value;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		GameObject headGameObject = this.gameObject;
		GameObject objectInCollision = other.gameObject;

		if (other.tag == SnakeConstants.wallTag || other.tag == SnakeConstants.snakeTag) {
			SceneManager.LoadScene ("EndGame");
			Destroy (headGameObject);
		} else if (other.tag == SnakeConstants.foodTag) {
			growing = true;
			Destroy (objectInCollision);
		}
	}
}


