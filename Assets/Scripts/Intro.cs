using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public string nextScene;
	public Sprite[] ponchoVariations;
	public Image poncho;

	void Start() {
		int variation = Random.Range(0, ponchoVariations.Length);
		Debug.Log("Choosed variation "+variation);
		poncho.sprite = ponchoVariations[variation];

		StaticPoncho.winPoncho = variation;
	}

	public void ShowPoncho() {
		poncho.enabled = true;
	}

	public void HidePoncho() {
		poncho.enabled = false;
	}

	public void OnAnimationFinish() {
		SceneManager.LoadScene(nextScene);
	}
}
