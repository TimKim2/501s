using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcOnClick : MonoBehaviour{

	public Interactable npcInteractable;

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
			if (npcInteractable != null) {

				Debug.Log ("Event Start");
				mesh.material.color = Color.green;

				npcInteractable.Interact ();
		
			}
		}
	}

	public void OnMouseExit()
	{
		isClick = false;
		mesh.material.color = Color.green;
	}

	public void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.tag == "Player") {
			Debug.Log ("Col");
		}
	}
}
