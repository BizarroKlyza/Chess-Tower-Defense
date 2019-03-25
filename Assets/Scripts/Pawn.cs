using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour {

	float range = 5.2f;
	float health = 100f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;
	Vector3 bulletDirection;

	public GameObject bullet;
	Bullet bulletScript;

	void Start() {
		bulletDirection = new Vector3(1f, 0f, 0f);
		bulletScript = bullet.GetComponent<Bullet>();
		InvokeRepeating("Fire", 1.0f, fireSpeed);
	}

	void Fire() {
		Instantiate(bullet, this.transform.position, Quaternion.identity);
		bulletScript.range = range;
		bulletScript.damage = damage;
		bulletScript.bulletSpeed = bulletSpeed;
		bulletScript.direction = bulletDirection;
	}
}
