using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[S.Serializable]
public struct TraitOpts {
	public string name;
	public SpriteRenderer traitRenderer;
	[HideInInspector]
	public int variationID;
	[HideInInspector]
	public bool isBlanco;
}

public class Person : MonoBehaviour {

	public TraitOpts[] traits;

	void Start() {
		GameController.instance.traitController.RandomizePerson(this);
	}

	void Spawn() {
		// Fall from the sky
 	}

	/* ------------- Traits --------------- */

	public int GetTraitVariation(S.String trait) {
		TraitOpts t = S.Array.Find(traits, x => x.name == trait);
		if(t.name == trait)
			return t.variationID;
		return -1;
	}

	// Set the internal data with no transition
	public void SetTraitVariation(S.String trait, int variationID,
								  Sprite sprite, bool isBlanco,
								  bool noAnimation=false) {

		TraitOpts t = S.Array.Find(traits, x => x.name == trait);
		if(t.name != trait)
			Debug.LogError("Trait "+trait+" does not exist", this);

		// TODO: animate

		t.traitRenderer.sprite = sprite;
		t.variationID = variationID;
		t.isBlanco = isBlanco;
	}
}
