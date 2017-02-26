using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private CharacterController characterController;
	[SerializeField] private float speed = 1.0f;

	// Use this for initialization
	void Start () {
		characterController = GetComponent<CharacterController> ();	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerMovement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));	

		characterController.SimpleMove (playerMovement * speed);
	}
}
