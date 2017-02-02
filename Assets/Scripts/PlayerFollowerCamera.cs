using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowerCamera : MonoBehaviour {

    public Transform PlayerPosition;

    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - PlayerPosition.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = PlayerPosition.transform.position + offset;
	}
}
