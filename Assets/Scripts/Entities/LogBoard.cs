using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBoard : MonoBehaviour {

	public GameObject symbolSet;

	float symbolSetsCount = 0f;

	void Awake () {
		GetComponent<Renderer>().enabled = false;
	}

	public void addSymbolSet(List<int> currentGlyphIdSequence) {

	}

	// Update is called once per frame
	void Update () {
		
	}
}
