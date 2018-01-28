using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Splash : MonoBehaviour {

	public string nextScene;

	void Update() {
		if(Input.GetButtonDown("Skip"))
			SceneManager.LoadScene(nextScene);
	}
}
