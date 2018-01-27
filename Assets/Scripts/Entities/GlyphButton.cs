using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlyphButton : MonoBehaviour {

	public string name;

	private bool clicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnMouseUp() {
		Debug.Log("Soy " + this.gameObject.name + "!");
	}

}
