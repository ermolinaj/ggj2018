using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphButton : MonoBehaviour {

	public int glyphId;
	public string inputButton;

	public Sprite pressed;
	[HideInInspector]
	public Sprite depressed;
	public Sprite generic;

	Image img;

	void Awake() {
		img = GetComponent<Image>();
		depressed = img.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		if(inputButton != "" && Input.GetButtonDown(inputButton)) {
			SelectGlyph();
			img.sprite = pressed;
		}
		if(inputButton != "" && Input.GetButtonUp(inputButton)) {
			img.sprite = depressed;
		}
	}

	void OnMouseUp() {
		SelectGlyph();
	}

	void SelectGlyph() {
		GameController.instance.glyphPressed(glyphId);
	}
}
