using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar  : MonoBehaviour {

	Image img;
	[Range(0f,1f)]
	public float initial=0;
	public float speed = .1f;

	public Color initialColor = Color.green;
	public Color finalColor = Color.red;

	float target;

	void Start() {
		img = GetComponent<Image>();
		img.fillAmount = initial;
		target = initial;
	}

	void Update() {
		if(target > img.fillAmount)
			img.fillAmount = Mathf.Min(img.fillAmount +
					Time.deltaTime * speed, target);
		else if(target < img.fillAmount)
			img.fillAmount = Mathf.Max(img.fillAmount -
					Time.deltaTime * speed, target);

		img.color = Color.Lerp(initialColor, finalColor, img.fillAmount);
	}

	public void setProgress(float prog) {
		target = prog;
	}
	
}