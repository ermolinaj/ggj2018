using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasFadeIn : MonoBehaviour {

	public float fadeInTime = 3f;

	CanvasGroup cr;

	void Start() {
		cr = GetComponent<CanvasGroup>();
		cr.alpha = 0;
	}

	void Update() {
		cr.alpha = Mathf.Min(cr.alpha + (1/fadeInTime) * Time.deltaTime, 1f);
	}
}
