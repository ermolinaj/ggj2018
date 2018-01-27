using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphButton : MonoBehaviour {

	public int glyphId;
	public string inputButton;
	
	// Update is called once per frame
	void Update () {
		if(inputButton != "" && Input.GetButtonDown(inputButton)) {
			SelectGlyph();
		}
	}

	void OnMouseUp() {
		SelectGlyph();
	}

	void SelectGlyph() {
		GameController.instance.glyphPressed(glyphId);
	}
}
