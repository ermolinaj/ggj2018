using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphButton : MonoBehaviour {

	//public string glyphReference;

	private bool clicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseUp() {
		GameObject gc = GameObject.FindGameObjectsWithTag ("GameController")[0];
			
		gc.SendMessage ("glyphPressed", this.gameObject.name);
	}

}
