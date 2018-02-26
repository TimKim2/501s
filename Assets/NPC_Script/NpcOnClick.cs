using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcOnClick : MonoBehaviour{

	public ReactionCollection npcReaction;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void OnMouseDown()
	{
		Debug.Log ("OnMouseDown");
		if (npcReaction != null) {

			Debug.Log ("Event Start");
			npcReaction.React ();
		}
	}
}
