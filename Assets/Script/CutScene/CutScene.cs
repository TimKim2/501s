using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour {

	public ReactionCollection startCutSceneReaction;

	// Use this for initialization
	void Start () {
		startCutSceneReaction.React ();
	}

}
