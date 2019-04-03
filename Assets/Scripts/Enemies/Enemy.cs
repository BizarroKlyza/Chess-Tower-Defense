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
	GameObject target;
	float timer = 0f;

	void Start() {
		velocity = new Vector3(-speed*Time.deltaTime, 0f, 0f);	
	}

	void Update() {
		if (health <= 0) {
            Instantiate(Resources.Load<GameObject>("Prefabs/World/Explosion"), this.transform.position, Quaternion.identity);
			Destroy(this.gameObject);
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

    void OnTriggerEnter(Collider other) {
		Debug.Log("LOG!");
        if (other.tag == "Player") {
            attacking = true;
			target = other.gameObject;
        }
    }
}
