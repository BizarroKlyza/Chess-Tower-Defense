using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

	List<GameObject> targets = new List<GameObject>();
	Enemy par;

	void Start() {
		par = transform.parent.parent.gameObject.GetComponent<Enemy>();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			par.attacking = true;
			targets.Add(other.gameObject);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (targets.Count == 0) {
				par.attacking = false;
			}
			targets.Remove(other.gameObject);
		}
		
	}
}
