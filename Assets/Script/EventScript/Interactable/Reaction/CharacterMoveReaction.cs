using UnityEngine;
using System.Collections;
public class CharacterMoveReaction : DelayedReaction
{
	public Transform destination;
	public CharacterScript character;
	public float speed;
	GameObject myCorotine;

	protected override void SpecificInit ()
	{
		//player = FindObjectOfType<PlayerScript>();
	}

	protected override void ImmediateReaction()
	{
		FSLocator.textDisplayer.reactionButton.enabled = false;
		Debug.Log ("StartMove");

		character.Move (destination.position, speed);

		myCorotine = CoroutineHandler.Start_Coroutine (CheckMoving()).gameObject;
	}
		

	IEnumerator CheckMoving()
	{
		Debug.Log ("Cor Start");

		while (character.getIsMoving()) {
			yield return null;
		}

		FSLocator.textDisplayer.reactionButton.enabled = true;
		Debug.Log ("Invoke");
		FSLocator.textDisplayer.reactionButton.onClick.Invoke ();

		Destroy(myCorotine);
	}
}