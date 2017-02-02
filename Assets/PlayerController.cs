using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    Vector3 velocity;
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    public void setVelocity(Vector3 _velocity)
    {
        velocity = _velocity;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);

    }
}
