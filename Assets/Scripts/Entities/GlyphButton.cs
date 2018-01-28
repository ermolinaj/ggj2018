using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlyphButton : MonoBehaviour, IPointerClickHandler
{

	public int glyphId;
	public string inputButton;

	public Sprite pressed;
	[HideInInspector]
	public Sprite depressed;
	public Sprite generic;

	Image img;

	void Awake ()
	{
		img = GetComponent<Image> ();
		depressed = img.sprite;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (inputButton != "" && Input.GetButtonDown (inputButton)) {
			SelectGlyph ();
		}
	}

	public void OnPointerClick (PointerEventData pev)
	{
		SelectGlyph ();
	}

	void OnMouseUp ()
	{
		SelectGlyph ();
	}

	void SelectGlyph ()
	{
		if (!GameController.instance.waitingForGlyphs)
			return;
		
		img.sprite = pressed;
		GameController.instance.glyphPressed (glyphId);

		StartCoroutine (DepressButtonIn (0.2f));
	}

	IEnumerator DepressButtonIn (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		img.sprite = depressed;
	}
}
