using UnityEngine;
using System.Collections;
public class PushBackReaction : DelayedReaction
{
	public Transform pushNpcTransform;
	public float speed;
	public float distance;

	private GameObject myCorotine;
	private PlayerScript player;

	protected override void SpecificInit ()
	{
		player = FindObjectOfType<PlayerScript>();
	}

	protected override void ImmediateReaction()
	{
		FSLocator.textDisplayer.reactionButton.enabled = false;

		Vector3 pushedVector = player.transform.position - pushNpcTransform.position;
		pushedVector.z = 0;
		Debug.Log ("Push ! : " + pushedVector.normalized);
		Vector3 destination = player.transform.position + pushedVector.normalized * distance;

		player.MoveReverse (destination, speed);

		myCorotine = CoroutineHandler.Start_Coroutine (CheckMoving()).gameObject;
	}


	IEnumerator CheckMoving()
	{

		while (player.getIsMoving()) {
			yield return null;
		}

		FSLocator.textDisplayer.reactionButton.enabled = true;
		FSLocator.textDisplayer.reactionButton.onClick.Invoke ();

		Destroy(myCorotine);
	}
}