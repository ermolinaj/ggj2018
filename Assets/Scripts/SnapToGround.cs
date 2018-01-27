using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGround : MonoBehaviour {

	public LayerMask layer;
	public float offset = 0;

	void Start () {
		RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit,
					Mathf.Infinity, layer)) {
			Vector3 p = transform.position;
			transform.position = new Vector3(p.x, hit.point.y + offset, p.z);
		}
	}
}