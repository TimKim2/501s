using UnityEngine;
using System.Collections;
public class CharacterMoveReaction : DelayedReaction
{
	public Transform destination;
	public PlayerScript player;
	public float speed;
	protected override void SpecificInit ()
	{
		player = FindObjectOfType<PlayerScript>();
	}

	protected override void ImmediateReaction()
	{
		player.Move (destination.position, speed);
	}
}