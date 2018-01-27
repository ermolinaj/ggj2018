using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public Transform target;
	public float yawVariation = 10;

	float yawOffset;

	void Start() {
		yawOffset = Random.Range(-yawVariation/2,yawVariation/2);
	}

	void Update () {
		transform.LookAt(target);
		transform.Rotate(0,yawOffset,0);
	}
}