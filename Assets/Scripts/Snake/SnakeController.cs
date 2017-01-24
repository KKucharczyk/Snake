using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	
public class SnakeController : MonoBehaviour
{
	private LinkedList<GameObject> body;

	public GameObject headPrefab;
	private GameObject headHandler;
	private HeadController headController;

	public GameObject tailPrefab;
    private GameObject tailHandler;
	private TailController tailController;

	public GameObject bodyPrefab;
	private BodyController bodyController;
    bool wasGrowing = false;

    void Awake() {
		headHandler = Instantiate (headPrefab, new Vector2(0.0f, 0.0f),  Quaternion.identity);
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

    public void grow() {
        prepareBodyPrefab();
        body.AddLast (createNewBodyPrefab());
        wasGrowing = true;
        this.toggleGrowing();
    }

    private void prepareBodyPrefab()
    {
        bodyController.setCurrentDirection(headController.getCurrentDirection());
        bodyController.setSpriteAccordingToPlane();
    }

    private GameObject createNewBodyPrefab() {
        return GameObject.Instantiate(bodyPrefab, headController.getCurrentPosition() - headController.getMovement(), Quaternion.identity);
    }

	public void setHeadSprite(Sprite sprite) {
		headController.setSprite (sprite);
	}

	public Sprite getHeadSprite(int index) {
		return headController.getSprite (index);
	}

	public void setMovement(Direction direction) {
		headController.setMovement (direction);
	}

	public void calculateNewHeadPosition() {
		headController.calculateCurrentPosition();
	}

	public void moveHead() {
		headController.moveSpriteToCurrentPosition();
	}

	public bool isGrowing() {
		return headController.getGrowing ();
	}

	public void toggleGrowing() {
		headController.setGrowing (false);
	}

    public void updateBodyLocation()
    {
        if (!hasAnyBody())
        {
            if (tailHandler != null)
                Destroy(tailHandler);
            tailController.createTail(headController.getCurrentDirection());
            tailHandler = Instantiate(tailPrefab, headController.getCurrentPosition() - headController.getMovement(), Quaternion.identity);
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
            /*
             *  Tail should not change its position while growing,
             *  this would make a bug, since new body sequence is first element, 
             *  therefore new tail would appear right before it. 
             */
            if (!wasGrowing)
            {
                Destroy(tailHandler);
                tailController.createTail(body.Last.Value.GetComponent<BodyController>().getCurrentDirection());
                tailHandler = Instantiate(tailPrefab, body.Last.Value.GetComponent<Transform>().position, Quaternion.identity);
            }
            bodyPrefab.GetComponent<BodyController>().setCurrentDirection(headController.getCurrentDirection());
            GameObject bodyHandler = Instantiate(bodyPrefab, headController.getCurrentPosition() - headController.getMovement(), Quaternion.identity);
            bodyHandler.GetComponent<BodyController>().init(getCurrentHeadDirection());

            body.AddBefore(body.First, bodyHandler);
            Destroy(body.Last.Value);
            body.RemoveLast();
        }
        wasGrowing = false;

    }

    public void moveSnake() {
        this.setMovement(this.getCurrentHeadDirection());
        this.setHeadSprite(this.getHeadSprite((int) this.getCurrentHeadDirection()));
        this.calculateNewHeadPosition();
        this.moveHead();
    }

}


