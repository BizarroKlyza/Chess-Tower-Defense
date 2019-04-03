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
		if (this.transform.position.x < -0.6f || this.transform.position.x > 7.6f
		|| this.transform.position.z < -0.6f || this.transform.position.z > 7.6f) {
			Destroy(this.gameObject);
		}
		if (Vector3.Distance(startPos, this.transform.position) > range) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!other.isTrigger) {
			if (other.tag == "Enemy") {
				other.gameObject.transform.parent.gameObject.GetComponent<Enemy>().health -= damage;
			}
			Destroy(this.gameObject);

		}
	}
}
