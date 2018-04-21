using UnityEngine;
using System.Collections.Generic;

public class SetFriendlyReaction : DelayedReaction
{
	public int friendly;
	public FriendShip friendShip;

	protected override void SpecificInit()
	{

	}


	protected override void ImmediateReaction()
	{
		friendShip.friendly += friendly;
	}
}