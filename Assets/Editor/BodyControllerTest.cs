using UnityEngine;
using NUnit.Framework;

public class BodyControllerTest : MonoBehaviour
{
    private IBodyController bodyController;
    private BodyController bodyControllerCheck;
	private GameObject bodyPrefab = SnakeSequenceFactory.createBodyController(new Vector2(0.0f, 0.0f));

    [Test]
    public void shouldInitializeBodyDirection()
    {
        // given
		bodyController = bodyPrefab.GetComponent<BodyController>();
		bodyControllerCheck = (BodyController)bodyController;
        Direction direction = Direction.RIGHT;

        // when
        bodyController.init(direction);

        // then
        Assert.That(bodyControllerCheck.CurrentDirection.Equals(Direction.RIGHT));
    }

    [Test]
    public void shouldSetSpriteAccordingToPlane_Vertical()
    {
        // given
		bodyPrefab.GetComponent<BodyController> ().CurrentDirection = Direction.UP;
		bodyController = bodyPrefab.GetComponent<BodyController>();
		bodyControllerCheck = (BodyController)bodyController;
		Sprite objectToCompare = bodyControllerCheck.getSprite(1);
		bodyControllerCheck.CurrentDirection = Direction.UP;

        // when
		bodyController.setSpriteAccordingToPlane(bodyControllerCheck.CurrentDirection);
        Sprite resultSprite = SnakeSequenceFactory.getReferenceToBodySpriteRenderer().sprite;

        // then
		Assert.That(resultSprite.Equals(objectToCompare));

    }

	[Test]
	public void shouldSetSpriteAccordingToPlane_Horizontal()
	{
		// given
		bodyPrefab.GetComponent<BodyController> ().CurrentDirection = Direction.LEFT;
		bodyController = bodyPrefab.GetComponent<BodyController>();
		bodyControllerCheck = (BodyController)bodyController;
		Sprite objectToCompare = bodyControllerCheck.getSprite(0);

		// when
		bodyController.setSpriteAccordingToPlane(bodyControllerCheck.CurrentDirection);
		Sprite resultSprite = SnakeSequenceFactory.getReferenceToBodySpriteRenderer().sprite;

		// then
		Assert.That(resultSprite.Equals(objectToCompare));
	}

    [Test]
    public void shouldSetSpriteAccordingToTurn()
    {
		// given
		bodyPrefab.GetComponent<BodyController> ().CurrentDirection = Direction.UP;
		bodyPrefab.GetComponent<BodyController> ().PreviousDirection = Direction.LEFT;
		bodyController = bodyPrefab.GetComponent<BodyController>();
		bodyControllerCheck = (BodyController)bodyController;
		Sprite objectToCompare = bodyControllerCheck.getSprite(4);

		// when
		bodyController.setSpriteAccordingToTurn(bodyControllerCheck.CurrentDirection, bodyControllerCheck.PreviousDirection	);
		Sprite resultSprite = SnakeSequenceFactory.getReferenceToBodySpriteRenderer().sprite;

		// then
		Assert.That(resultSprite.Equals(objectToCompare));
    }
}