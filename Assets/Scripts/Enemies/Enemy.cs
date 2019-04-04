using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float health = 100f;
	float speed = 0.3f;
	float damage = 10f;
	float attackSpeed= 0.5f;
	Vector3 velocity;
    public bool attacking;
	public GameObject target;
	float timer = 0f;
	public bool flashing = false;
	float flashTimer = 0f;
	float flashDur = 0.15f;

	MeshRenderer[] meshes;

	void Start() {
		velocity = new Vector3(-speed*Time.deltaTime, 0f, 0f);
		Component[] components = GetComponentsInChildren(typeof(MeshRenderer));
		meshes = new MeshRenderer[components.Length];
		for (int i = 0; i < components.Length; i++) {
			meshes[i] = components[i].GetComponent<MeshRenderer>();
		}
	}

	void Update() {
		if (health <= 0) {
            Instantiate(Resources.Load<GameObject>("Prefabs/World/Explosion"), this.transform.position + Vector3.up, Quaternion.identity);
			Destroy(this.gameObject);
		}
		if (flashing) {
			foreach (MeshRenderer mesh in meshes) {
				mesh.material = Resources.Load<Material>("Materials/Flash");
			}
			flashTimer += Time.deltaTime;
			if (flashTimer >= flashDur) {
				flashTimer = 0f;
				flashing = false;
				foreach (MeshRenderer mesh in meshes) {
					mesh.material = Resources.Load<Material>("Materials/Enemy");
				}
			}
		}
        if (attacking) {
			timer += Time.deltaTime;
			if (timer >= attackSpeed) {
				timer -= attackSpeed;
				target.GetComponent<Health>().health -= damage;
			}
        } else {
		    this.transform.position += velocity;
		}
	}
}
