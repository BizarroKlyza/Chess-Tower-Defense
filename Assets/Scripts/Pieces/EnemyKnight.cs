using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnight : Enemy {

	public override void Start() {
		health = 110f;
		damage = 15f;
		speed = 22.5f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
