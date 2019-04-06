using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Piece {

	public override void Start() {
		base.Start();
		mat = Resources.Load<Material>("Materials/Player");
	}

	public override void Update() {
		if (health <= 0) {
			transform.parent.gameObject.GetComponent<Placeable>().enabled = true;
		}
		base.Update();
	}
}
