using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : Player {

	float range = 8f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;
	Vector3 bulletDirection;
	Vector3 bulletDirection2;

	Vector3[] bulletDirs = {
	new Vector3(0f, 0f, -1f), new Vector3(0f, 0f, 1f ),
	new Vector3(1f, 0f, 0f ), new Vector3(-1f, 0f, 0f),
	new Vector3(0.7071067f, 0f, -0.7071067f), new Vector3(-0.7071067f, 0f, 0.7071067f ),
	new Vector3(0.7071067f, 0f, 0.7071067f ), new Vector3(-0.7071067f, 0f, -0.7071067f)};
	Vector3[] muzzles = {
	new Vector3(0.06f, 2.06f, -0.36f), new Vector3(-0.06f, 2.06f, 0.36f ),
	new Vector3(0.36f, 2.06f, 0.06f ), new Vector3(-0.36f, 2.06f, -0.06f),
	new Vector3(0.31f, 2.06f, -0.22f), new Vector3(-0.31f, 2.06f, 0.22f ),
	new Vector3(0.22f, 2.06f, 0.31f ), new Vector3(-0.22f, 2.06f, -0.31f)};

	public GameObject bullet;

	public override void Start() {
		health = 200f;
		base.Start();
	}

	void Fire() {
		for (int i = 0; i < 8; i++) {
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
