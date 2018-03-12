using UnityEngine;
using System.Collections;


public class DestinationReaction : DelayedReaction
{
	public Transform destination;
	Transform player;

	protected override void SpecificInit()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	protected override void ImmediateReaction()
	{
		player.position = destination.position;
	}
}