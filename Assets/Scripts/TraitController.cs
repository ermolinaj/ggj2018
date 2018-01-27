using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[S.Serializable]
public struct Trait {
	public S.String name;
	public GameObject prefab;
	public Sprite[] variations;

	[Tooltip("-1 for none")]
	public int blancoId;
};

public class TraitController : MonoBehaviour {

	public Trait[] fixedTraits;

	// Give a person random traits
	public void RandomizePerson(Person person) {
		person.ClearTraits();

		foreach(Trait t in fixedTraits) {
			int varId = Random.Range(0, t.variations.Length);
			Sprite variant = t.variations[varId];

			GameObject to = Instantiate(t.prefab, person.transform);
			to.GetComponent<SpriteRenderer>().sprite = variant;
			person.SetTraitVariation(t.name, to, varId, varId == t.blancoId);
		}
	}

	// Give everybody random traits
	public void RandomizeAllPeople() {
		foreach(var p in GameObject.FindGameObjectsWithTag("person")) {
			RandomizePerson(p.GetComponent<Person>());
		};
	}
}
