using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : Enemy {

	public override void Start() {
		health = 80f;
		damage = 10f;
		speed = 20f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
