using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public string targetTag;
	public float yawVariation = 10;

	public bool onlySetAtStart = true;

	float yawOffset;
	Transform target;

	void Start() {
		yawOffset = Random.Range(-yawVariation/2,yawVariation/2);
		target = GameObject.FindGameObjectWithTag(targetTag).transform;

		look();
	}

	void Update () {
		if(!onlySetAtStart) look();
	}

	void look() {
		transform.LookAt(target);
	}
}