using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int maxPersons = 20;
	public int maxGlyphs = 4;
	public GameObject person;

	List<string> glyphs = new List<string>();

	// Use this for initialization
	void Start () {
		for (var y = 0; y < maxPersons; y++) {
			var vector = new Vector2 (Random.Range (0, 10), Random.Range (0, 10));
			Instantiate (person, vector, Quaternion.identity);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");

		//Debug.Log (persons.Length);

	}

	public void glyphPressed(string glyphReference) {
		if (glyphs.Count < maxGlyphs) {
			this.glyphs.Add(glyphReference);
		}
		Debug.Log (string.Join (", ", glyphs.ToArray()));
	}

}