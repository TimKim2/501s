using UnityEngine;
using System.Collections;

public class EventEndReaction : DelayedReaction
{
	raycast m_raycast;

	protected override void SpecificInit()
	{
		m_raycast = FindObjectOfType<raycast>();
	}

    protected override void ImmediateReaction()
    {

        //대화 관련된 것들 전부 숨기기
		FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
		FSLocator.textDisplayer.reactionButton.gameObject.SetActive (false);
        FSLocator.textDisplayer.HideDialogueHolder();
        FSLocator.characterDisplayer.HideImage();
  
		m_raycast.enabled = true;
    }
}