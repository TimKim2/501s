using UnityEngine;
using System.Collections;


public class DelayReaction : DelayedReaction
{
    public float delayTime;
	GameObject myCorotine;

    protected override void ImmediateReaction()
    {
		FSLocator.textDisplayer.reactionButton.enabled = false;

		myCorotine = CoroutineHandler.Start_Coroutine(Delay()).gameObject;
    }

    IEnumerator Delay()
    {
		Debug.Log ("Cor Start");

        yield return new WaitForSeconds(delayTime);

		FSLocator.textDisplayer.reactionButton.enabled = true;
		Debug.Log ("Invoke");
		FSLocator.textDisplayer.reactionButton.onClick.Invoke ();

		Destroy(myCorotine);
    }
}