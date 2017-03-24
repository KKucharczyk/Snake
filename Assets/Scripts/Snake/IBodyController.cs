/// <summary>
/// Interface declares set of method necessary for manipulating body of snake. 
/// Those methods are mostly about manipulating visuals.
/// </summary>
public interface IBodyController
{
    /// <summary>
    /// Initialize snake's direction.
    /// Required for snake's tail.
    /// </summary>
    /// <param name="direction"></param>
    void init(Direction direction);

    /// <summary>
    /// Method sets snake's body part's sprite according to the plane it is currently on.
    /// Snake has two possible body parts: vertical and horizontal. Because plane is set only once, while creating
    /// new body part, it requires only current head direction to decide, which sprite should be used.
    /// </summary>
	void setSpriteAccordingToPlane(Direction direction);

    /// <summary>
    /// There are four possible turns, and each one has its own sprite. This method checks which turn has
    /// been done and then sets appropriate sprite.
    /// </summary>
    /// <param name="currentHeadDirection"></param>
    /// <param name="previousHeadDirection"></param>
    void setSpriteAccordingToTurn(Direction currentHeadDirection, Direction previousHeadDirection);

	void setCurrentDirection (Direction direction);
}

