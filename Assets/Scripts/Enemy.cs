using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 2;
	public GameObject[] waypoints;
	public float speed = 1.5f;

	private int index = 0;
	private Vector3 movementDirection;
	private Animator animator;
	private bool isDead = false;
	public bool IsDead { get { return isDead; } }

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		movementDirection = (waypoints [index].transform.position - gameObject.transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			transform.position += movementDirection * speed * Time.deltaTime;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "waypoint") {
			index++;

			if (index == waypoints.Length) {
				Debug.Log ("Hit the end");
				Destroy (gameObject);
			} else {
				movementDirection = (waypoints [index].transform.position - gameObject.transform.position).normalized;
			}
		}

		if (col.tag == "bullet") {
			health--;
			Destroy (col.gameObject);

			if (health <= 0) {
				isDead = true;
				GetComponent<Collider2D> ().enabled = false;
				animator.SetBool ("isDead", true);
				Destroy (gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
			}
		}
	}
}
