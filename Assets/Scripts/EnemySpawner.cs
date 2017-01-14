using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] waypoints;
	public float spawnSpeed = 1.0f;

	private float lastSpawnedTime = 0;
	private int chance = 30;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnedTime > spawnSpeed) {
			var ran = Random.Range (1, 100);
			if (ran < chance) {
				var enemy = Instantiate (enemies [Random.Range (0, enemies.Length - 1)]) as GameObject;
				enemy.transform.position = transform.position;
				enemy.GetComponent<Enemy> ().waypoints = waypoints;
				spawnSpeed = Mathf.Max (0.2f, spawnSpeed - 0.01f);
				chance = 30;
			} else {
				chance += 15;
			}

			lastSpawnedTime = Time.time;
		}
	}
}
