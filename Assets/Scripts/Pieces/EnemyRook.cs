using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRook : Enemy {

	public override void Start() {
		health = 100f;
		damage = 10f;
		speed = 0.5f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
