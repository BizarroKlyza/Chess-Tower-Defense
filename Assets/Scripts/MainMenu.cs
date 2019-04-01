using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject menuPanel, optionsPanel;

	public void LoadScene(int sceneId) {
		SceneManager.LoadScene(sceneId);
	}

	public void ExitGame() {

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		Application.Quit();
	}

	public void OptionsToggle(bool toggle) {
		if (toggle) {
			menuPanel.SetActive(false);
			optionsPanel.SetActive(true);

		}
		else {
			menuPanel.SetActive(true);
			optionsPanel.SetActive(false);
		}
	}
}
