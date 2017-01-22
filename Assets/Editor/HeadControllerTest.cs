using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class HeadControllerTest : MonoBehaviour{

	private HeadController headController;

	[SetUp] 
	public void SetUp() {
		headController = new HeadController();
	}

	[Test]
	public void shouldSetMovmentAccordingToDirection_right() {
		// given
		Direction direction = Direction.RIGHT;

		// when
		headController.setMovement(direction);

		// then
		Assert.AreEqual(headController.getMovement(), new Vector2 (1.0f, 0.0f));
	}

	[Test]
	public void shouldSetMovmentAccordingToDirection_left() {
		// given
		Direction direction = Direction.LEFT;

		// when
		headController.setMovement(direction);

		// then
		Assert.AreEqual(headController.getMovement(), new Vector2 (-1.0f, 0.0f));
	}

	[Test]
	public void shouldSetMovmentAccordingToDirection_up() {
		// given
		Direction direction = Direction.UP;

		// when
		headController.setMovement(direction);

		// then
		Assert.AreEqual(headController.getMovement(), new Vector2 (0.0f, 1.0f));
	}

	[Test]
	public void shouldSetMovmentAccordingToDirection_down() {
		// given
		Direction direction = Direction.DOWN;

		// when
		headController.setMovement(direction);

		// then
		Assert.AreEqual(headController.getMovement(), new Vector2 (0.0f, -1.0f));
	}
}
