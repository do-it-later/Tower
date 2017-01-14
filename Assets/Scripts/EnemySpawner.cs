using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] waypoints;
	public float spawnSpeed = 1.0f;

	private float lastSpawnedTime = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnedTime > spawnSpeed) {
			var enemy = Instantiate (enemies [Random.Range (0, enemies.Length - 1)]) as GameObject;
			enemy.transform.position = transform.position;
			enemy.GetComponent<WaypointMovement>().waypoints = waypoints;
			lastSpawnedTime = Time.time;
		}
		
	}
}
