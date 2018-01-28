using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasFader : MonoBehaviour
{

	public float fadeInTime = 4f;
	public float fadeOutTime = 3f;
	public bool fadingIn = true;

	CanvasGroup cr;

	void Start ()
	{
		cr = GetComponent<CanvasGroup> ();
		cr.alpha = 0;
	}

	public void FadeIn ()
	{
		fadingIn = true;	
	}

	public void FadeOut ()
	{
		fadingIn = false;	
	}

	void Update ()
	{
		if (fadingIn) {
			cr.alpha = Mathf.Min (cr.alpha + (1 / fadeInTime) * Time.deltaTime, 1f);
		} else {
			cr.alpha = Mathf.Max (cr.alpha - (1 / fadeInTime) * Time.deltaTime, 0f);
		}
	}
}
