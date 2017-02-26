using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraController : MonoBehaviour {

	[SerializeField] private Transform target;
	private float smoothing = 5.0f;
	private Vector3 offset;

	void Awake () {
		Assert.IsNotNull (target);
	}

	// Use this for initialization
	void Start () {
		offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
		float interpolant = smoothing * Time.deltaTime;
		Vector3 targetCamera = target.position + offset;
		
		transform.position = Vector3.Lerp (transform.position, targetCamera, interpolant);
	}
}
