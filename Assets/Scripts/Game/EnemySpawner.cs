// Written by Sinclair

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	[Header("Enemies")]
	public GameObject[] enemies;
	public Transform enemiesParent;
	int index = 0;
	float timer = -5f;
	float spawnRate = 0f;
	float waveTimer = 0f;

	public static int enem = 0;
	public GameOver gameOver;

	void Update() {
		if (enem >= 35) {
			gameOver.Won();
		}
		timer += Time.deltaTime;
		waveTimer += Time.deltaTime;
		if (timer >= spawnRate) {
			timer = 0f;
			//spawnRate = Random.Range(2f, 3f);
			spawnRate = (Mathf.Cos(waveTimer*0.2f)*1.5f) + 2.5f;
			index = Random.Range(0, enemies.Length);
			Instantiate(enemies[index], new Vector3(7f, 0f, Mathf.Round(Random.Range(0f, 7f))), Quaternion.identity, enemiesParent);
		}
	}
}

