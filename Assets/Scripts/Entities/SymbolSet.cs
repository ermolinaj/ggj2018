using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolSet : MonoBehaviour {

	public List<SpriteRenderer> symbols;
	public Sprite emptySymbol;

	// Use this for initialization
	void Start () {
		setEmptySymbols ();
	}

	public void setEmptySymbols() {
		foreach (SpriteRenderer s in symbols) {
			s.sprite = emptySymbol;
		}
	}

	public void renderGlyphs (List<int> currentGlyphIdSequence) {
		Dictionary<int, Sprite> symbolSprites = new Dictionary<int, Sprite> ();

		foreach(var gb in GameObject.FindGameObjectsWithTag("GlyphButton")) {
			int id = gb.GetComponent<GlyphButton>().glyphId;
			symbolSprites [id] = gb.GetComponent<SpriteRenderer> ().sprite;
		};

		for (int i = 0; i < currentGlyphIdSequence.Count; i++) {
			symbols [i].sprite = symbolSprites [currentGlyphIdSequence[i]];
		}

	}

}
