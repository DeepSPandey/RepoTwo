using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    PlayerController playerController;
    Rigidbody rb;

    public float playerSpeed;

	// Use this for initialization
	void Start () {
        playerController = GetComponent<PlayerController>();    
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 inputFromPlayer = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = inputFromPlayer.normalized * playerSpeed;
        playerController.setVelocity(moveVelocity);
    }
}
