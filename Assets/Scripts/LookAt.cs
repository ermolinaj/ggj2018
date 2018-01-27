using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform target;
	public float yawVariation = 0.1f;

	float yawOffset;

	void Start() {
		yawOffset = Random.Range(-yawVariation,yawVariation);
	}

	void Update () {
		transform.LookAt(target);
		transform.Rotate(0,yawOffset,0);
	}
}