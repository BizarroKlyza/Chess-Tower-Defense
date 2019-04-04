using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Piece : MonoBehaviour {

	public bool flashing;
	public float health;
	public float timer;
	public float flashTimer;
	
	MeshRenderer[] meshes;
	GameObject explosion;
	Material flashMat;
	public Material mat;

	public virtual void Start() {

		explosion = Resources.Load<GameObject>("Prefabs/World/Explosion");
		flashMat = Resources.Load<Material>("Materials/Flash");

		Component[] components = GetComponentsInChildren(typeof(MeshRenderer));
		meshes = new MeshRenderer[components.Length];
		for (int i = 0; i < components.Length; i++) {
			meshes[i] = components[i].GetComponent<MeshRenderer>();
		}
	}
	
	public virtual void Update() {

		if (health <= 0) {
			Instantiate(explosion, this.transform.position + Vector3.up, Quaternion.identity);
			Destroy(this.gameObject);
		}

		if (flashing) {
			foreach (MeshRenderer mesh in meshes) {
				mesh.material = flashMat;
			}
			flashTimer += Time.deltaTime;
			if (flashTimer >= 0.15f) {
				flashTimer = 0f;
				flashing = false;
				foreach (MeshRenderer mesh in meshes) {
					mesh.material = mat;
				}
			}
		}
	}
}
