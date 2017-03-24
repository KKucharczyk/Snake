using UnityEngine;
using NUnit.Framework;

public class BodyControllerTest : MonoBehaviour
{
    private IBodyController bodyController;
    private BodyController bodyControllerCheck;
	private GameObject bodyPrefab = SnakeSequenceFactory.createBodyController(new Vector2(0.0f, 0.0f));

    [SetUp]
    public void SetUp()
    {
		bodyPrefab.GetComponent<BodyController> ().CurrentDirection = Direction.LEFT;
		bodyController = bodyPrefab.GetComponent<BodyController>();
        bodyControllerCheck = (BodyController)bodyController;
    }

    [Test]
    public void shouldInitializeBodyDirection()
    {
        // given
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
		Sprite objectToCompare = bodyControllerCheck.getSprite(1);
		bodyControllerCheck.CurrentDirection = Direction.UP;

        // when
		bodyController.setSpriteAccordingToPlane(bodyControllerCheck.CurrentDirection);
        Sprite resultSprite = SnakeSequenceFactory.getReferenceToBodySpriteRenderer().sprite;

        // requires better sprite handling
		Assert.That(resultSprite.Equals(objectToCompare));

    }

	[Test]
	public void shouldSetSpriteAccordingToPlane_Horizontal()
	{
		// given
		Sprite objectToCompare = bodyControllerCheck.getSprite(0);

		// when
		bodyController.setSpriteAccordingToPlane(bodyControllerCheck.CurrentDirection);
		Sprite resultSprite = SnakeSequenceFactory.getReferenceToBodySpriteRenderer().sprite;

		// requires better sprite handling
		Assert.That(resultSprite.Equals(objectToCompare));
	}

    [Test]
    public void shouldSetSpriteAccordingToTurn()
    {
        // requires better sprite handling
    }
}