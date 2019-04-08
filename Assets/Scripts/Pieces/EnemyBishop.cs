﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBishop : Enemy {

	public override void Start() {
		health = 100f;
		damage = 10f;
		speed = 30f;
		attackSpeed = 0.5f;
		base.Start();
	}

	public override void Update() {
		base.Update();
	}
}
