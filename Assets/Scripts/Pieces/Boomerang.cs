using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

	float damage = 15f;
	public List<GameObject> enemies = new List<GameObject>();

	void OnTriggerEnter(Collider other) {
		if (!other.isTrigger) {
			if (other.tag == "Enemy") {
				GameObject gameObj = other.gameObject;
				if (!enemies.Contains(gameObj)) {
					enemies.Add(gameObj);
					Enemy enemy = gameObj.transform.parent.gameObject.GetComponent<Enemy>();
					enemy.health -= damage;
					enemy.flashing = true;
				}
			}	
		}
	}
}
