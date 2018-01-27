using System.Collections;
using System.Collections.Generic;

public enum ActionGlyph { Up, Down }

public struct GlyphSequence {
	public int poncho;
	public int hat;
	public ActionGlyph action;
}

public enum GlyphType {Hat, Poncho, Action};
