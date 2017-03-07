using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	[SerializeField] private Transform hero;
	
	private Animator anim;
	private NavMeshAgent nav;

	void Awake () {
		Assert.IsNotNull (hero);
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.Play ("Walk");

		nav.SetDestination (hero.position);
	}
}
