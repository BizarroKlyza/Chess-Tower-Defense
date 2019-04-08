using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRook : Enemy {

	public override void Start() {
		health = 250f;
		damage = 10f;
		speed = 10f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
