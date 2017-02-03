using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveImage : MonoBehaviour {

    //CanvasRenderer canvas;
	// Use this for initialization
   private touchPosition touchHandler;
   

    void Start () {
      touchHandler = GetComponent<touchPosition>(); 
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.touchCount > 0 )
        //{
        //    transform.position = Input.GetTouch(0).position;
        //}
        touchHandler.detectRegion();
        transform.position = touchHandler.joyposition();
	}
}
