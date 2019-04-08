using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public GameOver gameOver;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			gameOver.Lost();
		}
	}

	public void exitGame() {
		Application.Quit();
	} 
}
