using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToScene : MonoBehaviour {
	
	public string Destination = "";

	public void GoTo() {
		Application.LoadLevel (Destination);
	}

	void OnMouseDown() {
		GoTo ();
	}

}
