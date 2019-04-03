using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour {

	public float damage;
	public List<GameObject> enemies = new List<GameObject>();

	void OnTriggerEnter(Collider other) {
		if (!other.isTrigger) {
			if (other.tag == "Enemy") {
				GameObject gameObj = other.gameObject;
				if (!enemies.Contains(gameObj)) {
					enemies.Add(gameObj);
					gameObj.transform.parent.gameObject.GetComponent<Enemy>().health -= damage;
				}
			}	
		}
	}
}
