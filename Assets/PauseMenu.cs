using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject background;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Time.timeScale = background.activeSelf ? 1f : 0.01f;
			background.SetActive(!background.activeSelf);
		}
	}

	public void Resume() {
		background.SetActive(false);
		Time.timeScale = 1f;
	}
}
