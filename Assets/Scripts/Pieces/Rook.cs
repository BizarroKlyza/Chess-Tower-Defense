using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : MonoBehaviour {

	float range = 8.2f;
	float health = 100f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;
	Vector3 bulletDirection;

	Vector3 muzzle = new Vector3(0.2f, 1f, 0f);

	public GameObject bullet;
	Bullet bulletScript;

	float timer = 0f;

	void Start() {
		bulletDirection = new Vector3(1f, 0f, 0f);
		bulletScript = bullet.GetComponent<Bullet>();
	}

	void Fire() {
		Instantiate(bullet, this.transform.position + muzzle, Quaternion.identity);
		bulletScript.range = range;
		bulletScript.damage = damage;
		bulletScript.bulletSpeed = bulletSpeed;
		bulletScript.direction = bulletDirection;
	}

	void Update() {
		timer += Time.deltaTime;
		if (timer >= fireSpeed) {
			timer -= fireSpeed;
			Fire();
		}
	}
}
