using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : MonoBehaviour {

	float range = 8f;
	float health = 100f;
	float damage = 20f;
	float bulletSpeed = 5f;
	float fireSpeed = 1.5f;
	Health healthScript;

	Vector3[] bulletDirs = { new Vector3(0.7071067f, 0f, -0.7071067f), new Vector3(0.7071067f, 0f, 0.7071067f) };
	Vector3[] muzzles = { new Vector3(0.15f, 1f, -0.15f), new Vector3(0.15f, 1f, 0.15f) };

	public GameObject bullet;

	float timer = 0f;

	void Start() {
		healthScript = this.GetComponent<Health>();
		healthScript.health = health;
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
	
	void Update() {
		timer += Time.deltaTime;
		health = healthScript.health;
		if (health <= 0) {
			Instantiate(Resources.Load<GameObject>("Prefabs/World/Explosion"), this.transform.position + Vector3.up, Quaternion.identity);
			transform.parent.gameObject.GetComponent<Placeable>().enabled = true;
			Destroy(this.gameObject);
		}
		if (timer >= fireSpeed) {
			timer -= fireSpeed;
			Fire();
		}
	}
}
