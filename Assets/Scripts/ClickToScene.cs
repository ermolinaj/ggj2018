using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToScene : MonoBehaviour {

	public CanvasFader fader;
	public string nextScene;

	void Update() {
		if(Input.GetButtonDown("Skip")) {
			if(fader != null) {
				fader.FadeOut();
				Invoke("gotoScene", fader.fadeOutTime);
			} else {
				gotoScene();
			}
		}
	}

	void gotoScene() {
		SceneManager.LoadScene(nextScene);
	}
}
