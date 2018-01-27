using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionGlyph { Up, Down }

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int maxPersons = 20;
	public int maxGlyphs = 4;
	public GameObject person;

	public TraitController traitController;

	List<string> glyphs = new List<string>();

	void Awake() {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
	}

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
