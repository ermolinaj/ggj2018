using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int numPersons = 20;
	public int maxGlyphs = 4;
	public GameObject person;
	public Transform personSpawner;

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
		SpawnPeople(numPersons);
		
		// Generate the glyphOrder
		glyphOrder = new List<GlyphType>()
			{GlyphType.Hat, GlyphType.Poncho, GlyphType.Action};
		waitingForGlyphs = true;
	}

	void SpawnPeople(int n) {
		Vector2 centre = new Vector2(
			personSpawner.position.x, personSpawner.position.z);
		Vector2 scale = new Vector2(
			personSpawner.localScale.x, personSpawner.localScale.z);

		for (var i = 0; i < n; i++) {
			Vector2 xz = Random.insideUnitCircle;
			var vector = new Vector3 (xz.x * scale.x + centre.x,
									  0,
									  xz.y * scale.y + centre.y);
			Instantiate (person, vector, Quaternion.identity);
		}
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
