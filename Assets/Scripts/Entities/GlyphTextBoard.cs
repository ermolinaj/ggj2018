using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class GlyphTextBoard : MonoBehaviour {

	Text txt;
	public static GlyphTextBoard instance = null;

	List<char> representation;

	void Awake() {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
	}

	public void setRepresentation(List<char> representation) {
		this.representation = representation;
	}

	void Start () {
		txt = gameObject.GetComponent<Text>();
		txt.text = "hola wachines\n";
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void showGlyphs(List<List<int>> secuences) {
		string t = "";
		foreach (List<int> s in secuences) {
			foreach (int i in s) {
				t += representation [i];
			}
			t += '\n';
		}
		txt.text = t;
	}
}
