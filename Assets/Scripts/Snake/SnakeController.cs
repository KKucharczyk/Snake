using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class SnakeController : MonoBehaviour
{
	private LinkedList<GameObject> body;

	private GameObject headHandler;
	private HeadController headController;

	public GameObject tailPrefab;
    private GameObject tailHandler;
	private TailController tailController;

	public GameObject bodyPrefab;
	private BodyController bodyController;
    bool wasGrowing = false;

    void Awake() {
        headHandler = SnakeSequenceFactory.createHeadController(new Vector2(0.0f, 0.0f));
		headController = headHandler.GetComponent<HeadController> ();
		bodyController = bodyPrefab.GetComponent<BodyController> ();
		tailController = tailPrefab.GetComponent<TailController> ();
        body = new LinkedList<GameObject>();
    }

	public Direction getCurrentHeadDirection() {
		return headController.getCurrentDirection();
	}

    public void setCurrentHeadDirection(Direction direction)
    {
        headController.setCurrentDirection(direction);
    }

    public Direction getPreviousHeadDirection() {
		return headController.getPreviousDirection();
	}

	public void setPreviousHeadDirection(Direction direction) {
		headController.setPreviousDirection(direction);
	}

    private bool hasAnyBody()
    {
        return body.Count > 0;
    }

    public bool isGrowing()
    {
        return headController.getGrowing();
    }

    public void grow() {
        bodyController.setSpriteAccordingToPlane();
        SnakeSequenceFactory.getReferenceToBodyController().setCurrentDirection(headController.getCurrentDirection());
        body.AddLast (SnakeSequenceFactory.createBodyController(headController.getCurrentPosition() - headController.getMovement()));
        wasGrowing = true;
        headController.setGrowing(false);
    }

    public void moveSnake() {
        headController.setMovement(this.getCurrentHeadDirection());
        headController.setSprite(headController.getSprite((int) this.getCurrentHeadDirection()));
        headController.calculateCurrentPosition();
        headController.moveSpriteToCurrentPosition();
    }

    public void updateBodyLocation()
    {
        if (!hasAnyBody())
        {
            if (tailHandler != null)
                Destroy(tailHandler);
            tailController.createTail(headController.getCurrentDirection());
            tailHandler = SnakeSequenceFactory.createTailController(headController.getCurrentPosition() - headController.getMovement());
        }
        else
        {
            if (headController.isDirectionChanged())
            {
                bodyController.setSpriteAccordingToTurn(headController.getCurrentDirection(), headController.getPreviousDirection());
                headController.setPreviousDirection(getCurrentHeadDirection());
            }
            else
            {
                bodyController.setSpriteAccordingToPlane();
            }
 
            if (!wasGrowing)
            {
                Destroy(tailHandler);
                
                tailController.createTail(body.Last.Value.GetComponent<BodyController>().getCurrentDirection());
                tailHandler = SnakeSequenceFactory.createTailController(body.Last.Value.GetComponent<Transform>().position);
            }
            SnakeSequenceFactory.getReferenceToBodyController().setCurrentDirection(headController.getCurrentDirection());
            
            GameObject bodyHandler = SnakeSequenceFactory.createBodyController(headController.getCurrentPosition() - headController.getMovement());
            bodyHandler.GetComponent<BodyController>().init(getCurrentHeadDirection());

            body.AddBefore(body.First, bodyHandler);
            Destroy(body.Last.Value);
            body.RemoveLast();
        }
        wasGrowing = false;

    }

}


