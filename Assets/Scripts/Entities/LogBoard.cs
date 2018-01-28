using S = System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogBoard : MonoBehaviour {

	public GlyphButton[] buttons;

	public int historyLogSize = 10;
	public GameObject logLine;
	public float logSpacing = 10;

	public CanvasScaler cScaler;

	Queue<GameObject> log = new Queue<GameObject>();

	public void addSymbolSet(List<int> glyphSeq) {
		// move the others down
		foreach(var ll in log) {
			Vector3 p = ll.transform.position;
			ll.GetComponent<RectTransform>().position =
				new Vector3(p.x, p.y+logSpacing*cScaler.scaleFactor/2, p.z);
		}

		GameObject l =
			Instantiate(logLine, logLine.transform.position,
				logLine.transform.rotation, transform);
		RectTransform rt = l.GetComponent<RectTransform>();
		rt.anchorMax = new Vector2(1,1);
		rt.anchorMin = new Vector2(1,1);
		rt.pivot = new Vector2(1,1);
		rt.anchoredPosition = Vector3.zero;

		setLogLine(l.GetComponent<LogLine>(), glyphSeq);
		log.Enqueue(l);

		if(log.Count > historyLogSize) {
			var go = log.Dequeue();
			Object.Destroy(go);
		}
	}

	void setLogLine(LogLine ll, List<int> glyphSeq) {
		List<Sprite> ss = new List<Sprite>();

		foreach(var g in glyphSeq) {
			var gb = S.Array.Find(buttons, b => b.glyphId == g);
			ss.Add(gb.generic);
		}

		ll.setSprites(ss);
	}
}
