using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	public string targetTag;
	public float yawVariation = 10;

	float yawOffset;
	Transform target;

	void Start() {
		yawOffset = Random.Range(-yawVariation/2,yawVariation/2);
		target = GameObject.FindGameObjectWithTag(targetTag).transform;
	}

	void Update () {
		transform.LookAt(target);
		var rot = transform.rotation;
		transform.rotation = Quaternion.Euler(0,rot.y + yawOffset,0);
	}
}