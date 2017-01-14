using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour {

	public GameObject[] waypoints;
	public float speed = 1.5f;

	private int index = 0;
	private Vector3 movementDirection;

	// Use this for initialization
	void Start () {
		movementDirection = (waypoints [index].transform.position - gameObject.transform.position).normalized;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += movementDirection * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "waypoint") {
			index++;

			if (index == waypoints.Length) {
				Debug.Log ("Hit the end");
				Destroy (gameObject);
			} else {
				movementDirection = (waypoints [index].transform.position - gameObject.transform.position).normalized;
			}
		}
	}
}
