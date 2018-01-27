﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int numPersons = 20;
	public int maxGlyphs = 4;
	public int maxRetries = 15;

	public GameObject person;
	public Transform personSpawner;

	public TraitController traitController;

	List<char> symbols = new List<char> {'△', '□', 'X', 'O', 'A', 'B', 'C'};
	List<char> symbolsToUse;

	List<List<int>> glyphIdSequences = new List<List<int>>();
	List<int> currentGlyphIdSequence = new List<int> ();
	List<GlyphType> glyphOrder;

	bool waitingForGlyphs = false;
	GlyphSequence currSequence = new GlyphSequence();
	int currGlyphInSeq = 0;
	int currentTry = 0;
	int winColor;

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

		// Generating the subset of symbols to use as representation
		symbolsToUse = symbols.OrderBy (x => Random.Range(0, 100)).Take (maxGlyphs).ToList();
		Debug.Log(new string(symbolsToUse.ToArray()));
		GlyphTextBoard.instance.setRepresentation (symbolsToUse);

		// Setting the color of poncho everyone must use for you to win
		winColor = Random.Range (0, maxGlyphs);

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
		currentGlyphIdSequence.Add (glyphId);
		if(currGlyphInSeq >= glyphOrder.Count)
			CompleteGlyphSequence();
	}

	void CompleteGlyphSequence() {
		Debug.Log("Completed a new sequence");
		traitController.TransitionTraits(currSequence);

		glyphIdSequences.Add (currentGlyphIdSequence);
		currentGlyphIdSequence = new List<int> ();
		currSequence = new GlyphSequence();
		currGlyphInSeq = 0;
	
		GlyphTextBoard.instance.showGlyphs (glyphIdSequences);

		currentTry += 1;

	}

	void CheckFinishConditions() {
		if (traitController.CheckIfEverybodyHaveSameColor (winColor)) {
			Debug.Log ("Ganaste!");
		}
		if (currentTry >= maxRetries) {
			Debug.Log ("Perdiste!");
		}
	}

}
