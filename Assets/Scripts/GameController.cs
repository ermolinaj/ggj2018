using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int maxPersons = 20;
	public int maxGlyphs = 4;
	public GameObject person;

	public TraitController traitController;

	List<GlyphSequence> sequences = new List<GlyphSequence>();
	List<GlyphType> glyphOrder;

	bool waitingForGlyphs = false;
	GlyphSequence currSequence = new GlyphSequence();
	int currGlyphInSeq = 0;

	void Awake() {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		// Create the people
		for (var y = 0; y < maxPersons; y++) {
			var vector = new Vector2 (Random.Range (-20, 20),
									  Random.Range (-1.5f, 4));
			Instantiate (person, vector, Quaternion.identity);
		}
		
		// Generate the glyphOrder
		glyphOrder = new List<GlyphType>()
			{GlyphType.Hat, GlyphType.Poncho, GlyphType.Action};
		waitingForGlyphs = true;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");

		//Debug.Log (persons.Length);

	}

	/* ------------- Glyph sequences ------------ */

	public void glyphPressed(int glyphId) {
		// TODO: randomize glyphId orders
		if (!waitingForGlyphs) return;

		GlyphType type = glyphOrder[currGlyphInSeq];
		switch(type) {
			case GlyphType.Hat:
				Debug.Log("Selected hat " + glyphId);
				currSequence.hat = glyphId;
				break;
			case GlyphType.Poncho:
				Debug.Log("Selected poncho " + glyphId);
				currSequence.poncho = glyphId;
				break;
			case GlyphType.Action:
				currSequence.action = glyphId % 2 == 0
					? ActionGlyph.Down : ActionGlyph.Up;
				Debug.Log("Selected action " + currSequence.action);
				break;
		}

		currGlyphInSeq++;
		if(currGlyphInSeq >= glyphOrder.Count)
			CompleteGlyphSequence();
	}

	void CompleteGlyphSequence() {
		Debug.Log("Completed a new sequence");
		traitController.TransitionTraits(currSequence);

		sequences.Add(currSequence);
		currSequence = new GlyphSequence();
		currGlyphInSeq = 0;
	}

}
