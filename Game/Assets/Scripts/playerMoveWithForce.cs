﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMoveWithForce : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        //transform.Rotate(x, x, 0);
        transform.Translate(x, 0, z);
    }
}
