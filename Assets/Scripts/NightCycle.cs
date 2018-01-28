using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCycle : MonoBehaviour {

	int numSteps;
	int currStep = 0;

	Quaternion initialRotation;

	public Quaternion finalRotation =
		Quaternion.Euler(170, -30, 0);
	Quaternion stepRotation;
	Quaternion currRotTarget;

	public float transitionSpeed = 0.3f;

	Light lightComp;
	public Color initialColor = Color.white;
	public Color finalColor;
	Color currColorTarget;
	public int colorTransitionStartStep;

	public Transform sunLight;

	void Start() {
		numSteps = GameController.instance.maxRetries;

		initialRotation = sunLight.transform.rotation;
		currRotTarget = initialRotation;

		lightComp = sunLight.GetComponent<Light>();
		currColorTarget = initialColor;
		colorTransitionStartStep = numSteps / 2;
	}

	void FixedUpdate() {
		sunLight.rotation =
			Quaternion.Lerp(sunLight.rotation, currRotTarget,
				Time.deltaTime * transitionSpeed);

		lightComp.color =
			Color.Lerp(lightComp.color, currColorTarget,
				Time.deltaTime * transitionSpeed);
	}

	public void oneStep() {
		currStep++;

		currRotTarget = Quaternion.Slerp(initialRotation, finalRotation,
			(float)currStep / (float)numSteps);

		if(currStep >= colorTransitionStartStep) {
			currColorTarget = Color.Lerp(initialColor, finalColor,
				(float)(currStep - colorTransitionStartStep)
					/ (float)(numSteps-colorTransitionStartStep));
		}
	}
	
}