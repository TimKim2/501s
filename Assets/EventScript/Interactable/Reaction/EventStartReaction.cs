using UnityEngine;

public class EventStartReaction : DelayedReaction
{
	//CharacterManager characterManager;

	protected override void SpecificInit()
	{
		//TVNTManager.instance.ReferenceTVNTManager (ref characterManager);
	}


    protected override void ImmediateReaction()
    {
		//characterManager.PlayerController.keyState = (TVNTPlayerController.JoystickKey.NONE);
		FSLocator.textDisplayer.reactionButton.gameObject.SetActive (true);

		FSLocator.textDisplayer.ShowDialogueHolder ();

		//TutorialController.Instance.HideButton ();

    }
}