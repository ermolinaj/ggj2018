using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour {
	
	public string Destination = "";

	public void GoTo() {
		SceneManager.LoadScene(Destination);
	}

	void OnMouseDown() {
		GoTo ();
	}

}
