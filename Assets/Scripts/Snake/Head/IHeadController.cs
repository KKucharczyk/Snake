using UnityEngine;

public interface IHeadController
{
	/// <summary>
	/// Main method, moves snake's head to new position.
	/// 
	/// First there is a preparation for move, which consists of setting sprite and 
	/// calculating actual move, then the head's position is changed.
	/// </summary>
	void move ();

	/// <summary>
	/// Checks if current position is equal to previous one.
	/// </summary>
	/// <returns><c>true</c>, if direction was changed, <c>false</c> otherwise.</returns>
	bool isDirectionChanged ();
}
