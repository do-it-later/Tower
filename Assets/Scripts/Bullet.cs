using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private GameObject target;
	private float spawnTime;

	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (target.GetComponent<Enemy>().IsDead) {
			Destroy (gameObject);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, 5.0f * Time.deltaTime);
		}

		if (Time.time - spawnTime > 3) {
			Destroy (gameObject);
		}
	}

	public void SetTarget(GameObject target) {
		this.target = target;
	}
}
