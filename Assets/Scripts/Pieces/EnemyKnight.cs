using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : Enemy {

	public override void Start() {
		health = 90f;
		damage = 15f;
		speed = 0.4f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
