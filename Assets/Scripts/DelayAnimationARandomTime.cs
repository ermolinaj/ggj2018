using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class DelayAnimationARandomTime : MonoBehaviour
{
	public float MinSeconds = 0f;
	public float MaxSeconds = 10f;
	private float Remaining;

	public float AlterAnimationSpeedUpToPercent = 10f;

	void Start ()
	{
		Remaining = Random.Range (MinSeconds, MaxSeconds);
		this.GetComponent<Animator> ().speed = this.GetComponent<Animator> ().speed * (1 + (AlterAnimationSpeedUpToPercent / 100) * Random.Range (-1f, 1f));
		this.GetComponent<Animator> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Remaining -= Time.deltaTime;

		if (Remaining <= 0) {
			this.enabled = false;
			this.GetComponent<Animator> ().enabled = true;
		}
	}
}
