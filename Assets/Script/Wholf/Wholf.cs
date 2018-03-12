using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wholf : MonoBehaviour {

	public ReactionCollection reaction;

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			if (reaction) {
				reaction.InitIndex ();
				reaction.React ();
			}
		}
	}
}
