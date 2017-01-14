using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public GameObject[] waypoints;
	public float spawnSpeed = 0.3f;

	private float lastSpawnedTime = 0;
	private int baseChance = 10;
	private int prngIncrease = 1;
	private int chance;

	// Use this for initialization
	void Start () {
		chance = baseChance;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnedTime > spawnSpeed) {
			var ran = Random.Range (1, 100);
			if (ran < chance) {
				var enemy = Instantiate (enemies [Random.Range (0, enemies.Length - 1)]) as GameObject;
				enemy.transform.position = transform.position;
				enemy.GetComponent<Enemy> ().waypoints = waypoints;
				chance = baseChance;
				prngIncrease += 1;
			} else {
				chance += prngIncrease;
			}

			lastSpawnedTime = Time.time;
		}
	}
}
