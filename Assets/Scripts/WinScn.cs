﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScn : MonoBehaviour {

	public Sprite[] ponchoVariations;
	public Image poncho;
	public Text percent;

	void Start() {
		poncho.sprite = ponchoVariations[StaticStats.winPoncho];
		percent.text = "" +
			(int)(100f * (float)StaticStats.convertedCount
				/ StaticStats.personCount)
			+ "%";
	}
}