using UnityEngine;

public class EventStartReaction : DelayedReaction
{
	//CharacterManager characterManager;
	raycast m_raycast;

	protected override void SpecificInit()
	{
		//TVNTManager.instance.ReferenceTVNTManager (ref characterManager);
		m_raycast = FindObjectOfType<raycast>();
	}


    protected override void ImmediateReaction()
    {
		//characterManager.PlayerController.keyState = (TVNTPlayerController.JoystickKey.NONE);
		FSLocator.textDisplayer.reactionButton.gameObject.SetActive (true);

		FSLocator.textDisplayer.ShowDialogueHolder ();

		m_raycast.enabled = false;

		//TutorialController.Instance.HideButton ();

    }
}