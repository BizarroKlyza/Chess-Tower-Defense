using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float range;
	public float damage;
	public float bulletSpeed;
	public Vector3 direction;
	Vector3 startPos;

	void Start() {
		startPos = this.transform.position;
		direction = Vector3.Normalize(direction);
	}

	void Update() {
		this.transform.position += direction*bulletSpeed*Time.deltaTime;
		if (Vector3.Distance(startPos, this.transform.position) > range) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		GameObject otherGameObject = other.gameObject;
		if (otherGameObject.CompareTag("Enemy")) {
			otherGameObject.GetComponent<Enemy>().health -= damage;
		}
		Destroy(this.gameObject);
	}
}
