using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTablet : MonoBehaviour {

	public static ObjectiveTablet instance = null;

	public SpriteRenderer trait;

	void Awake() {
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}

	public void setTrait(Sprite traitToRender) {
		trait.sprite = traitToRender;
	}
}
