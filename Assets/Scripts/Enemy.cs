using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 100f;
	float speed = 0.3f;
	float damage = 20f;
	float damageSpeed = 1f;
	Vector3 velocity;
	void Start() {
		velocity = new Vector3(speed*Time.deltaTime, 0f, 0f);	
	}

	void Update() {
		if (health <= 0) {
			Destroy(this.gameObject);
		}
		this.transform.position -= velocity;
	}
}
