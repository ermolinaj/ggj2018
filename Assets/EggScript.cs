using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.CompilerServices;

public class EggScript : MonoBehaviour
{

	public float Speed = 10;

	// Update is called once per frame
	void Update ()
	{
		Vector3 forward = this.transform.forward;
		forward.y = 0f;

		if (Input.GetKey (KeyCode.W)) {
			this.transform.position += forward * Speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.S)) {
			this.transform.position -= forward * Speed * Time.deltaTime;
		}
		if (Input.GetKey (KeyCode.A)) {
			this.transform.RotateAround (this.transform.position, Vector3.up, -6 * Speed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.D)) {
			this.transform.RotateAround (this.transform.position, Vector3.up, 6 * Speed * Time.deltaTime);
		}
	}
}
