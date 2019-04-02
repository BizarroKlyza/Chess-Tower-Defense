using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

	public float damage;
	public List<GameObject> enemies = new List<GameObject>();

	void OnTriggerEnter(Collider other) {
		GameObject otherGameObject = other.gameObject;
		if (otherGameObject.CompareTag("Enemy")) {
			if (!enemies.Contains(otherGameObject)) {
				enemies.Add(otherGameObject);
				otherGameObject.GetComponent<Enemy>().health -= damage;
			}
		}
	}
}
