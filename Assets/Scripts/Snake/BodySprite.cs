using System;

/// <summary>
/// Enum determines body sprite and isolates it from main logic.
/// 
/// Name convention: first direction is the direction before turn. Second one is direction right after the turn.
/// 
/// TO DO: maybe connect it somehow with spriteRenderer? I cannot look at such a hardcoded values.
/// </summary>
public enum BodySprite
{
    UNDEFINED = -1,
    HORIZONTAL = 0,
    VERTICAL = 1,
    NORTH_WEST = 2,
    NORTH_EAST = 4,
    SOUTH_WEST = 3,
    SOUTH_EAST = 5
}

public static class BodySpritesUtils
{
    public static int toInt(this BodySprite bodySprite)
    {
        return Convert.ToInt32(bodySprite);
    }
}


