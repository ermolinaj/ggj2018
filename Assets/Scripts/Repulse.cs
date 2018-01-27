using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulse : MonoBehaviour {

	public string repulseTag;
	public float force = 1;

	private Rigidbody rb;

	void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	void Update () {
		foreach(var o in GameObject.FindGameObjectsWithTag(repulseTag)) {
			applyRepulsion(o);
		}
	}

	void applyRepulsion(GameObject target) {
		Rigidbody trb = target.GetComponent<Rigidbody>();
		Vector3 repulseDiff = target.transform.position - transform.position;
		float sqrRepulse = repulseDiff.sqrMagnitude;
		float repulseMass = trb.mass;
		trb.AddForce(repulseDiff / -sqrRepulse * repulseMass * force);
	}
}
