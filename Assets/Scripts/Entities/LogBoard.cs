using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBoard : MonoBehaviour {

	public GameObject symbolSet;

	float symbolSetsCount = 0f;
	// Use this for initialization
	void Awake () {
		GetComponent<Renderer>().enabled = false;
	}

	public void addSymbolSet(List<int> currentGlyphIdSequence) {

		Vector3 pos = gameObject.transform.position;
		pos.y -= symbolSetsCount;
		//Vector3 pos = new Vector3(0, symbolSetsCount, 0);
		GameObject p = Instantiate (symbolSet, pos, symbolSet.transform.rotation, transform);

		SymbolSet newSet = p.GetComponent<SymbolSet> ();

		p.transform.rotation = Quaternion.identity;
		newSet.renderGlyphs(currentGlyphIdSequence);
		//p.transform.localScale = new Vector3 (.1f, .1f, .1f);
		//p.transform.SetParent (transform);

		symbolSetsCount += 0.15f;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
