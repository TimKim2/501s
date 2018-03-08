using UnityEngine;

public class StopMoveReaction : DelayedReaction
{
	protected override void SpecificInit()
	{

	}


	protected override void ImmediateReaction()
	{
		//GameObject.FindGameObjectWithTag ("Player").GetComponent<TVNTPlayerController> ().enabled = false;
	}
}