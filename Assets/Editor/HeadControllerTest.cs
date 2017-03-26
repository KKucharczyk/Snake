using UnityEngine;
using NUnit.Framework;

[TestFixture ()]
public class HeadControllerTest : MonoBehaviour
{
	private IHeadController headController;
	private HeadController headControllerCheck;

	[Test ()]
	public void shouldMove ()
	{
        // TO DO: 
        // install NSubstitute into project, then all tests become trivial.
	}

	[Test ()]
	public void shouldCheckIfHeadDirectionHasChanged ()
	{
		// given
		headController = new HeadController ();
		headControllerCheck = (HeadController)headController;
		headControllerCheck.CurrentDirection = Direction.UP;
		headControllerCheck.CurrentDirection = Direction.LEFT;

		// when
		bool result = headController.isDirectionChanged ();

		// then
		Assert.True (result);
	}

	[Test ()]
	public void shouldCheckIfHeadDirectionHasChanged_invalid ()
	{
		// given
		headController = new HeadController ();
		headControllerCheck = (HeadController)headController;
		headControllerCheck.CurrentDirection = Direction.RIGHT;
		headControllerCheck.PreviousDirection = Direction.RIGHT;

		// when
		bool result = headController.isDirectionChanged ();

		// then
		Assert.False (result);
	}
}


