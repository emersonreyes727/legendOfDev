using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour {
	// 1
	private CharacterController characterController;
	[SerializeField] private float speed = 1.0f;

	// 2
	[SerializeField] private LayerMask layerMask;
	private Vector3 currentLookTarget = Vector3.zero;

	// 3
	private Animator anim;

	// Use this for initialization
	void Start () {
		// 1
		characterController = GetComponent<CharacterController> ();	
		// 3
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// 1
		Vector3 playerMovement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));	
		characterController.SimpleMove (playerMovement * speed);

		// 3
		if (playerMovement == Vector3.zero) {
			anim.SetBool ("IsWalking", false);
		} else {
			anim.SetBool ("IsWalking", true);
		}
		// 3
		if (Input.GetMouseButtonDown(0)) {
			anim.Play ("Spin Attack");
		} else if (Input.GetMouseButtonDown(1)) {
			anim.Play ("Double Chop");
		}
	}

	void FixedUpdate () {
		// 2
		// this is for Physics.Raycast below
		RaycastHit hit;
		// Screenpointtoray - returns a ray from the camera to the mouse position (Input.mousePosition)
		// Camera.main is the Main Camera
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * 500, Color.blue);

		// returns true if all conditions are met
		if (Physics.Raycast(ray, out hit, 500, layerMask, QueryTriggerInteraction.Ignore)) {
			if (hit.point != currentLookTarget) {
				currentLookTarget = hit.point;
			}

			Vector3 targetPosition = new Vector3 (hit.point.x, transform.position.y, hit.point.z);
			Quaternion rotation = Quaternion.LookRotation (targetPosition - transform.position);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * 10f);
		}
	}
}
