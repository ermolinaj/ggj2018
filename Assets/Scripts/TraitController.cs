using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[S.Serializable]
public struct Trait {
	public S.String name;
	public GameObject prefab;
	public Sprite[] variations;
	public int blancoId; // -1 for none
};

public class TraitController : MonoBehaviour {

	public Trait[] fixedTraits;

	// Give a person random traits
	public void RandomizePerson(Person person) {
		person.traits.Clear();

		foreach(Trait t in fixedTraits) {
			Sprite variant = t.variations[Random.Range(0, t.variations.Length)];
			GameObject to = Instantiate(t.prefab, person.transform);
			to.GetComponent<SpriteRenderer>().sprite = variant;
			person.traits[t.name] = to;
		}
	}

	// Give everybody random traits
	public void RandomizeAllPeople() {
		foreach(var p in GameObject.FindGameObjectsWithTag("person")) {
			RandomizePerson(p.GetComponent<Person>());
		};
	}
}
