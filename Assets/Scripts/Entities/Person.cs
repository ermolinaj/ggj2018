using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[S.Serializable]
public struct TraitOpts {
	public string name;
	public SpriteRenderer traitRenderer;
}

public class Person : MonoBehaviour {

	public TraitOpts[] traits;
	
	Dictionary<string, int> variationIds = new Dictionary<string, int>();
	Dictionary<string, bool> isBlancos = new Dictionary<string, bool>();

	void Start() {
		GameController.instance.traitController.RandomizePerson(this);
	}

	void Spawn() {
		// Fall from the sky
 	}

	/* ------------- Traits --------------- */

	public int GetTraitVariation(string trait) {
		if(variationIds.ContainsKey(trait))
			return variationIds[trait];
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
		variationIds[trait] = variationID;
		isBlancos[trait] = isBlanco;
	}
}
