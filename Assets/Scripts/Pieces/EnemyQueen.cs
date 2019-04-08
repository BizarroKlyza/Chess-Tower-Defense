using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueen : Enemy {

	public override void Start() {
		health = 200f;
		damage = 10f;
		speed = 27.5f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
