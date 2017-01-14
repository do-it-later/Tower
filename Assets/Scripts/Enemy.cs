using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int health = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "bullet") {
			health--;
			Destroy (col.gameObject);

			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
