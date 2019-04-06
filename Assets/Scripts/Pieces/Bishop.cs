using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Player {

	float range = 8f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;

	Vector3[] bulletDirs = { new Vector3(0.7071067f, 0f, -0.7071067f), new Vector3(0.7071067f, 0f, 0.7071067f) };
	Vector3[] muzzles = { new Vector3(0.15f, 1f, -0.15f), new Vector3(0.15f, 1f, 0.15f) };

	public GameObject bullet;


	public override void Start() {
		health = 100f;
		base.Start();
	}

	void Fire() {
		for (int i = 0; i < 2; i++) {
			Bullet bulScript = Instantiate(bullet, this.transform.position + muzzles[i], Quaternion.identity).GetComponent<Bullet>();
			bulScript.range = range;
			bulScript.damage = damage;
			bulScript.bulletSpeed = bulletSpeed;
			bulScript.direction = bulletDirs[i];
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
