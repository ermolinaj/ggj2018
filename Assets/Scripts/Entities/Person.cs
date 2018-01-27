using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	struct TraitOpts {
		public int id;
		public GameObject traitO;
		public bool isBlanco;
	}

	private Dictionary<S.String, TraitOpts> traits;

	void Awake()
	{
		traits = new Dictionary<S.String, TraitOpts>();
	}

	void Start() {
		GameController.instance.traitController.RandomizePerson(this);
		Spawn();
	}

	void Spawn() {
		// Fall from the sky
	}

	/* ------------- Traits --------------- */

	public int GetTraitVariation(S.String trait) {
		if(traits.ContainsKey(trait))
			return traits[trait].id;
		return -1;
	}

	// Set the internal data with no transition
	public void SetTraitVariation(S.String trait, GameObject go,
								  int variationID, bool isBlanco,
								  bool noAnimation=false) {

		if(traits.ContainsKey(trait))
			Destroy(traits[trait].traitO);

		// TODO: animate

		traits[trait] = new TraitOpts() {
			id = variationID,
			traitO = go,
			isBlanco = isBlanco,
		};
	}

	public void ClearTraits() {
		traits.Clear();
	}

}
