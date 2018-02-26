using UnityEngine;
using System.Collections;


public class DelayReaction : DelayedReaction
{
    public float delayTime;
	GameObject myCorotine;

    protected override void ImmediateReaction()
    {
        //Debug.Log("Is Delay?");
        //FSLocator.controlManager.m_Button.enabled = false;
		myCorotine = CoroutineHandler.Start_Coroutine(Delay()).gameObject;
    }

    IEnumerator Delay()
    {

        yield return new WaitForSeconds(delayTime);
		//if (TutorialController.Instance.afterDelayReaction != null) {
			//TutorialController.Instance.afterDelayReaction.React ();
	
		//}

		//Destroy(myCorotine);
    }
}