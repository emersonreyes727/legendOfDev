using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	[SerializeField] private float range = 3.0f;
	[SerializeField] private float timeBetweenAttacks = 1.0f;

	private Animator anim;
	private GameObject player;
	private BoxCollider[] weapons;
	private bool playerInRange;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();	
		player = GameManager.instance.Player;
		weapons = GetComponentsInChildren<BoxCollider> ();	

		StartCoroutine (attack());
	}	
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, player.transform.position) < range) {
			playerInRange = true;
		} else {
			playerInRange = false;
		}
	}

	IEnumerator attack () {
		if (playerInRange && !GameManager.instance.GameOver) {
			anim.Play ("Attack");
			yield return new WaitForSeconds (timeBetweenAttacks);
		}
		yield return null;
		StartCoroutine (attack());
	}
}
