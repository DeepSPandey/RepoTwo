using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchPosition : MonoBehaviour {

	// Use this for initialization
    private Vector2 pos;
    private Vector2 inputVector;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            pos = Input.GetTouch(0).position;
         //   Debug.Log(pos);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {     
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).position-pos;
            Vector2 normalizeDeltaPos = touchDeltaPosition / 25.0f;
            normalizeDeltaPos = (normalizeDeltaPos.magnitude > 1) ? normalizeDeltaPos.normalized : normalizeDeltaPos;
            Debug.Log("normalize:" + normalizeDeltaPos);
            Debug.Log("origin:"+pos);
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
}
