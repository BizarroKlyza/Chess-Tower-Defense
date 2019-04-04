using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Header("Enemies")]
	public GameObject[] enemies;
	public Transform enemiesParent;
	int index = 0;
	float timer = 0f;
	float spawnRate = 3f;

	void Update() {
		timer += Time.deltaTime;
		if (timer >= spawnRate) {
			timer -= spawnRate;
			index = Random.Range(0, enemies.Length);
			Instantiate(enemies[index], new Vector3(7f, 0f, Mathf.Round(Random.Range(0f, 7f))), Quaternion.identity, enemiesParent);
		}
	}
}
