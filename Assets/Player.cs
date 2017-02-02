using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    PlayerController playerController;
    Rigidbody rb;

    public float playerSpeed;

    public float maxSwipeTime;
    public float minSwipeDistance;

    float startTime;
    float stopTime;

    Vector3 startPos;
    Vector3 endPos;

    float swipeDistance;
    float swipeTime;

    Vector2 xyMovement;

    // Use this for initialization
    void Start () {
        playerController = GetComponent<PlayerController>();
        xyMovement = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update ()
    { 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                stopTime = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = stopTime - startTime;

                if (swipeTime < maxSwipeTime && swipeDistance > minSwipeDistance)
                {
                    xyMovement = swipe();
                }
            }

        }
        Vector3 inputFromPlayer = new Vector3(xyMovement.x, 0, xyMovement.y);
        Vector3 moveVelocity = inputFromPlayer.normalized * playerSpeed;
        playerController.setVelocity(moveVelocity);
    }

    Vector2 swipe()
    {
        float xMov = 0, yMov = 0;
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("Horizontal Swipe");
            xMov = distance.x < 0 ?  -1 : 1;
            //Debug.Log(distance.x - distance.y);
        }
        else if (Mathf.Abs(distance.x) <= Mathf.Abs(distance.y))
        {
            Debug.Log("Vertical Swipe");
            yMov = distance.y < 0 ? -1 : 1;
        }
        return new Vector2(xMov, yMov);
    }
}
