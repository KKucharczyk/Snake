using System;
using UnityEngine;

/// <summary>
/// Class persists all constants, like tags and movment vectors.
/// </summary>
public class SnakeConstants
{
	public static readonly string snakeTag = "Snake";
	public static readonly string wallTag = "Wall";
	public static readonly string foodTag = "Food";

	public static readonly Vector2 movmentUp = new Vector2 (0.0f, 1.0f);
	public static readonly Vector2 movmentDown = new Vector2 (0.0f, -1.0f);
	public static readonly Vector2 movmentLeft = new Vector2 (-1.0f, 0.0f);
	public static readonly Vector2 movmentRight = new Vector2 (1.0f, 0.0f);
}


