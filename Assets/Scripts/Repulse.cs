using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulse : MonoBehaviour {

	public string repulseTag;
	public float strength = -0.01f;

	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		foreach(var o in GameObject.FindGameObjectsWithTag(repulseTag)) {
			if(o != this)
				applyRepulsion(o);
		}
	}

	void applyRepulsion(GameObject target) {
		Rigidbody trb = target.GetComponent<Rigidbody>();
		Vector3 repulseDiff = target.transform.position - transform.position;
		float sqrDist = repulseDiff.sqrMagnitude;
		sqrDist = Mathf.Pow(sqrDist, 2);
		float repulseMass = trb.mass;

		float div = -sqrDist * repulseMass * strength;
		if(div > float.Epsilon) {
			repulseDiff /= div;
			repulseDiff = new Vector3(
				Mathf.Clamp(repulseDiff.x, -1, 1),
				Mathf.Clamp(repulseDiff.y, -1, 1),
				Mathf.Clamp(repulseDiff.z, -1, 1)
			);
			trb.AddForce(repulseDiff);
		}
	}
}
