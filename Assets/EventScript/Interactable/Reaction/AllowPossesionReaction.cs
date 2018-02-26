using UnityEngine;
using System.Collections;

public class AllowPossesionReaction : DelayedReaction
{
	GameObject[] corpseList;

	protected override void SpecificInit ()
	{
		
	}
	
	protected override void ImmediateReaction()
	{
		corpseList = GameObject.FindGameObjectsWithTag("Corpse");

		for (int i = 0; i < corpseList.Length; i++) {
			//corpseList [i].GetComponent<Corpse> ().enabled = true;
		}
	}
}