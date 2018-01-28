using S = System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[S.Serializable]
public struct Spawner {
	public BoxCollider box;
	public int numPersons;
}

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	public int maxGlyphs = 4;
	public int maxRetries = 15;

	public GameObject person;
	public Spawner[] personSpawners;
	public Spawner[] disposablePersonSpawnern;
	public float personDistance = 1;

	public TraitController traitController;
	public SymbolSet principalSymbolSet;
	public LogBoard logBoard;

	List<char> symbols = new List<char> {'△', '□', 'X', 'O', 'A', 'B', 'C'};
	List<char> symbolsToUse;

	List<List<int>> glyphIdSequences = new List<List<int>>();
	List<int> currentGlyphIdSequence = new List<int> ();
	List<GlyphType> glyphOrder;

	bool waitingForGlyphs = false;
	GlyphSequence currSequence = new GlyphSequence();
	int currGlyphInSeq = 0;
	int currentTry = 0;
	[HideInInspector]
	public int winColor;

	void Awake() {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
		
		// Generate the glyphOrder
		glyphOrder = new List<GlyphType>()
			{GlyphType.Hat, GlyphType.Poncho, GlyphType.Action};

		// Generating the subset of symbols to use as representation
		symbolsToUse = symbols.OrderBy (x => Random.Range(0, 100)).Take (maxGlyphs).ToList();
		Debug.Log(new string(symbolsToUse.ToArray()));

		// Setting the color of poncho everyone must use for you to win
		winColor = Random.Range (0, maxGlyphs);

		waitingForGlyphs = true;
	}

	// Use this for initialization
	void Start () {
		foreach(var s in personSpawners)
			SpawnPeople(s.numPersons, s.box, false);
		foreach(var s in disposablePersonSpawnern)
			SpawnPeople(s.numPersons, s.box, true);

		Trait poncho = traitController.getTrait ("poncho");
		ObjectiveTablet.instance.setTrait (poncho.variations[winColor]);
	}

	void SpawnPeople(int n, BoxCollider spawner, bool disposable) {
		List<Vector2> positions = new List<Vector2>();
		bool allPositioned = false;
		float sqrDistance = Mathf.Pow(personDistance,2);
		for(int j=0; j < 20; j++) {
			// Try to position all the people with new coordinates
			positions = new List<Vector2>();

			for (int i=0; i < n; i++) {
				// Try to position person i, preserving previous positions
				allPositioned = false;
				for(var attempt = 0; attempt < 50; attempt++) {
					Vector3 sp = spawner.transform.position;

					float x = Random.Range(
						sp.x - spawner.size.x / 2,
						sp.x + spawner.size.x / 2
					);
					float z = Random.Range(
						sp.z - spawner.size.z / 2,
						sp.z + spawner.size.z / 2
					);
					Vector2 xz = new Vector2(x,z);

					if(positions.Any(v => (v - xz).SqrMagnitude() < sqrDistance))
							continue;

					positions.Add(xz);
					allPositioned = true;
					break;
				}
				if(!allPositioned) {
						Debug.LogWarning("Failed to position person number "+i
												+", retrying");
						break;
				}
			}

			if(allPositioned) {
					break;
			}
		}
		if(!allPositioned) {
			Debug.LogError("Failed to position all the people :(");
		}

		foreach(Vector2 pos in positions) {
			var vector = new Vector3 (pos.x, 0, pos.y);
			GameObject p = Instantiate (person, vector, Quaternion.identity);
			p.GetComponent<Person>().SendMessage("Setup", disposable);
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
		principalSymbolSet.renderGlyphs (currentGlyphIdSequence);
		if(currGlyphInSeq >= glyphOrder.Count)
			CompleteGlyphSequence();
	}

	void CompleteGlyphSequence() {
		Debug.Log("Completed a new sequence");
		traitController.TransitionTraits(currSequence);

		logBoard.addSymbolSet(currentGlyphIdSequence);

		currentGlyphIdSequence = new List<int> ();
		currSequence = new GlyphSequence();
		currGlyphInSeq = 0;
	
		principalSymbolSet.setEmptySymbols ();

		currentTry += 1;
		CheckFinishConditions ();

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
