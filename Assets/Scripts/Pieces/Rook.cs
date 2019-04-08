using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : Player {

	float range = 8.2f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;

	Vector3[] bulletDirections = { new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f) };
	Vector3[] muzzles = { new Vector3(0f, 1f, -0.2f), new Vector3(0f, 1f, 0.2f) };

	public GameObject bullet;
	Bullet bulletScript;

	public override void Start() {
		health = 300f;
		base.Start();
	}

	void Fire() {
		for (int i = 0; i < 2; i++) {
			bulletScript = Instantiate(bullet, this.transform.position + muzzles[i], Quaternion.identity).GetComponent<Bullet>();
			bulletScript.range = range;
			bulletScript.damage = damage;
			bulletScript.bulletSpeed = bulletSpeed;
			bulletScript.direction = bulletDirections[i];
		}
	}

	public override void Update() {
		base.Update();
		timer += Time.deltaTime;
		if (timer >= fireSpeed) {
			timer -= fireSpeed;
			Fire();
		}
	}
}
