using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed = 1.0f;
	public float searchRadius = 3.0f;
	public float fireRate = 1.0f;

	private GameObject target;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnBullet", fireRate, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnBullet () {
		foreach (Collider2D col in Physics2D.OverlapCircleAll(transform.position, searchRadius)) {
			if (col.tag == "enemy") {
				target = col.gameObject;
				break;
			}
		}

		if (target != null) {
			var newBullet = Instantiate (bullet, transform.position, bullet.transform.rotation) as GameObject;
			newBullet.GetComponent<Bullet>().SetTarget (target);
		}
	}
}
