using UnityEngine;

class TouchControl : IControl
{
    public float minSwipeDistY = 20f;
    public float minSwipeDistX = 20f;
    private static Vector2 startPos = Vector2.zero;

    public Direction getNewDirection(Direction currentHeadDirection)
    {
        Direction newHeadDirection = Direction.UNDEFINED;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                
                case TouchPhase.Moved:
                    if(startPos == Vector2.zero)
                        startPos = touch.position;
                    break;
                case TouchPhase.Ended:
                    
                    float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    if (swipeDistVertical > minSwipeDistY)
                    {
                        float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
                        if (swipeValue > 0) 
                            newHeadDirection = Direction.UP;
                        else if (swipeValue < 0) 
                            newHeadDirection = Direction.DOWN;
                    }
                    
                    float swipeDistHorizontal = (new Vector3(touch.position.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    
                    if (swipeDistHorizontal > minSwipeDistX)
                    {
                        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                        if (swipeValue > 0) 
                            newHeadDirection = Direction.RIGHT;
                        else if (swipeValue < 0)
                            newHeadDirection = Direction.LEFT;
                    }
                    startPos = Vector2.zero;
                    break;
            }
        }
        return newHeadDirection;
    }
}

