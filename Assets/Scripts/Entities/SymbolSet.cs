using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolSet : MonoBehaviour {

	public Image[] symbols;
	public GlyphButton[] buttons;

	// Use this for initialization
	void Start () {
		setEmptySymbols ();
	}

	public void setEmptySymbols() {
		foreach (Image s in symbols) {
			s.enabled = false;
		}
	}

	public void renderGlyphs (List<int> currentGlyphIdSequence) {
		for (int i = 0; i < currentGlyphIdSequence.Count; i++) {
			int id = currentGlyphIdSequence[i];
			GlyphButton gb = S.Array.Find(buttons, g => g.glyphId == id);

			symbols[i].enabled = true;
			Image img = symbols[i];
			img.sprite = gb.generic;
		}
	}

}
