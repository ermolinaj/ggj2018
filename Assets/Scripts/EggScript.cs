using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;

public class EggScript : MonoBehaviour
{

	public float Speed = 10;

	// Update is called once per frame
	void Update ()
	{
		Vector3 forward = this.transform.forward;
		forward.y = 0f;

		float vertical = Input.GetAxis ("Vertical");
		float horizontal = Input.GetAxis ("Horizontal");

		this.transform.position += vertical * forward * Speed * Time.deltaTime;

		this.transform.RotateAround (this.transform.position,
			horizontal * Vector3.up, 6 * Speed * Time.deltaTime);
	}
}
