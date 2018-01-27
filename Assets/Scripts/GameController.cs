using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public int persons = 20;
	public GameObject person;

	// Use this for initialization
	void Start () {
		
		for (var y = 0; y < persons; y++) {
			var vector = new Vector2 (Random.Range (0, 10), Random.Range (0, 10));
			Instantiate (person, vector, Quaternion.identity);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] persons = GameObject.FindGameObjectsWithTag("Person");

		//Debug.Log (persons.Length);

	}
}