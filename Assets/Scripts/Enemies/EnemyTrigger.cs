using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour {

	public Enemy par;

	GameObject piece;

	void Start() {
		Debug.Log("YO");
		par = transform.parent.parent.gameObject.GetComponent<Enemy>();
	}
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			par.attacking = true;
			piece = other.gameObject.transform.parent.gameObject;
			par.target = piece;
		}
	}

	void Update() {
		if (!piece) {
			par.attacking = false;
		}
	}
}
