using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGame : MonoBehaviour {

	public GameObject blackPanel;
	public ReactionCollection startReacitonCollection;

	// Use this for initialization
	void Start () {
		//blackPanel.SetActive (true);
		startReacitonCollection.InitIndex();
		startReacitonCollection.React ();

	}

	public void Test() {
		Debug.Log ("test");
	}
}
