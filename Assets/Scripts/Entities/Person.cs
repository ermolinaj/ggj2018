using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour {

	public Dictionary<S.String, GameObject> traits;

	void Awake()
	{
		traits = new Dictionary<S.String, GameObject>();
	}

	void Start() {
		GameController.instance.traitController.RandomizePerson(this);
	}

}
