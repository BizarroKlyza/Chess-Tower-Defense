using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Piece {

	public float damage;
	public float speed;
	public float attackSpeed;
	Vector3 velocity;

    public bool attacking;
	public GameObject target;

	public override void Start() {
		base.Start();
		mat = Resources.Load<Material>("Materials/Enemy");
		velocity = new Vector3(-speed*Time.deltaTime, 0f, 0f);
	}

	public override void Update() {
		if (health <= 0) {
			EnemySpawner.enem++;
		}
		base.Update();
        if (attacking) {
			timer += Time.deltaTime;
			if (timer >= attackSpeed) {
				timer -= attackSpeed;
				target.GetComponent<Piece>().health -= damage;
				target.GetComponent<Piece>().flashing = true;
			}
        } else {
		    transform.position += velocity * Time.deltaTime;
		}
		if (!target) {
			attacking = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			attacking = true;
			target = other.gameObject.transform.parent.gameObject;
		}
	}
}
