using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogLine : MonoBehaviour {

	public Image[] positions;

	public void setSprites(List<Sprite> glyphs) {
		for(int i=0; i<glyphs.Count; i++) {
			positions[i].sprite = glyphs[i];
		}
	}
}
