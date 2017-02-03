using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPosition : MonoBehaviour
{

    // Use this for initialization
    private Vector2 pos;
    private Vector2 inputVector;
    private Rect leftBox = new Rect(0, 0, Screen.width / 2, Screen.height);
    private Rect RightBox = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);
    private int rightId;
    private int leftId;
    private int leftRegionCount = 0;
    private int rightRegionCount = 0;


    struct touchRegion
    {
        public Rect box;
        public int touchCount;
        public int tocuhID;
        public Vector2 position;


    };
    //void Start()
    //{
    //    Debug.Log(RightBox);
    //    Debug.Log(leftBox);
    //    //  touchRegion middle;

    //}

    // Update is called once per frame
   //// void Update()
   // {
   //     detectRegion();
       
   // }
    public void handleInput(Touch touch)
    {
       //  Debug.Log("in HandleInput" + touch.fingerId  );
        if (touch.phase == TouchPhase.Moved && touch.fingerId == leftId)
        {
            // Get movement of the finger since last frame
            Debug.Log("Moving finger is" + touch.fingerId);

            Vector2 touchDeltaPosition = touch.position - pos;
            Vector2 normalizeDeltaPos = touchDeltaPosition / 25.0f;
            normalizeDeltaPos = (normalizeDeltaPos.magnitude > 1) ? normalizeDeltaPos.normalized : normalizeDeltaPos;
            Debug.Log("normalize:" + normalizeDeltaPos + "origin:" + pos);
            inputVector = normalizeDeltaPos;


        }
    }
    public float horizontal()
    {

        return inputVector.x;

    }
    public float vertical()
    {
        return inputVector.y;
    }
    public Vector2 joyposition()
    {
        return inputVector*50+pos;
    }
    public void detectRegion()
    {
        if (Input.touchCount > 0)
        {
         //   Debug.Log("touch count" + Input.touchCount);
            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (leftBox.Contains(touch.position))
                        {
                            leftRegionCount++;
                            Debug.Log("Left Region Count " + leftRegionCount);

                            if (leftRegionCount == 1)
                            {
                                leftId = touch.fingerId; //save id when count =1
                                pos = touch.position;    // save id when count =1
                                Debug.Log("Left Region ID: " + leftId + " touch position" + pos);
                            }
                        }
                        break;
                    case TouchPhase.Canceled:
                        if(touch.fingerId==leftId)
                        {leftRegionCount = 0;
                           inputVector=Vector2.zero;}// check region
                        break;
                    case TouchPhase.Ended:
                        if (touch.fingerId == leftId)
                        {leftRegionCount = 0;  //check region
                        inputVector = Vector2.zero;
                        }break;
                    case TouchPhase.Moved:
                        handleInput(touch);
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

