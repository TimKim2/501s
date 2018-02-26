using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcOnClick : MonoBehaviour{

	public ReactionCollection npcReaction;

	private MeshRenderer mesh;

	private bool isClick = false;


	// Use this for initialization
	void Start () {
		mesh = gameObject.GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void OnMouseDown()
	{
		mesh.material.color = Color.red;
		isClick = true;

	}

	public void OnMouseUp()
	{
		Debug.Log ("OnMouseDown");
		if (isClick) {
			if (npcReaction != null) {

				Debug.Log ("Event Start");
				mesh.material.color = Color.green;

				npcReaction.InitIndex ();
				npcReaction.React ();
			}
		}
	}

	public void OnMouseExit()
	{
		isClick = false;
		mesh.material.color = Color.green;
	}
}
