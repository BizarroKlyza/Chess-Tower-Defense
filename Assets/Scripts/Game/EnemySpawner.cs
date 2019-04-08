// Written by Sinclair

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

	int enem = 0;
	public GameOver gameOver;

	void Update() {
		timer += Time.deltaTime;
		if (timer >= spawnRate) {
			enem++;
			if (enem >= 5) {
				gameOver.Won();
			}
			timer -= spawnRate;
			index = Random.Range(0, enemies.Length);
			Instantiate(enemies[index], new Vector3(7f, 0f, Mathf.Round(Random.Range(0f, 7f))), Quaternion.identity, enemiesParent);
		}
	}
}

