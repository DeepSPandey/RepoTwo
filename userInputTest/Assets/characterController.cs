using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour {
    public float movementSpeed=5.0f;
    public float drag=0.5f;
    public float rotationSpeed=15f;
//    private touchPosition inputTouch;

    private Vector2 pos;
    private Vector2 inputVector;
    private Rigidbody rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        rbody.drag = drag;
        rbody.maxAngularVelocity = rotationSpeed;
		
	}
	
	// Update is called once per frame
	void Update () {
        getDirection();
        Vector3 dir = Vector3.zero;
        dir.x = inputVector.x;
        dir.z = inputVector.y;
        if (dir.magnitude > 1)
        {
            dir.Normalize();
        }
        rbody.AddForce(dir * movementSpeed);
       // rbody.AddForce(new Vector3(5.0f,0.0f,0.0f));

	
    }
    public void getDirection()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            pos = Input.GetTouch(0).position;
            //   Debug.Log(pos);
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Get movement of the finger since last frame
            Vector2 touchDeltaPosition = Input.GetTouch(0).position - pos;
            Vector2 normalizeDeltaPos = touchDeltaPosition / 10.0f;
            normalizeDeltaPos = (normalizeDeltaPos.magnitude > 1) ? normalizeDeltaPos.normalized : normalizeDeltaPos;
            Debug.Log("normalize:" + normalizeDeltaPos);
            Debug.Log("origin:" + pos);
            inputVector = normalizeDeltaPos;


        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            inputVector = Vector3.zero;
        }
    }
}
