using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject lostMenu;
	public GameObject wonMenu;

	public void Lost() {
		Time.timeScale = 0.2f;
		lostMenu.SetActive(true);
	}
	
	public void Won() {
		Time.timeScale = 0.2f;
		wonMenu.SetActive(true);
	}

	public void ExitToMain() {
		Time.timeScale = 1.0f;
		lostMenu.SetActive(false);
		wonMenu.SetActive(false);
		SceneManager.LoadScene(0);
	}
}
