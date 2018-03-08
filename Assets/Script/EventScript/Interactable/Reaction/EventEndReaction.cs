using UnityEngine;
using System.Collections;

public class EventEndReaction : DelayedReaction
{
    protected override void ImmediateReaction()
    {

		//TutorialController.Instance.reactionButton.onClick.RemoveAllListeners();

        //스크린 버튼 비활성화
		//TutorialController.Instance.reactionButton.gameObject.SetActive(false);
		//FSLocator.characterDisplayer.HideImage ();
        //플레이어 움직임 활성화 (수정 요망)
        // FSLocator.controlManager.m_Player.move_sp = 1.5f;
        //조이스틱 활성화 (수정 요망)
        //FSLocator.controlManager.m_Joystick.OnJoystick();
		//FSLocator.controlManager.m_JoyStickPanel.SetActive (true);
        //UI버튼 활성화
        //FSLocator.controlManager.m_UIObj.SetActive(true);

        //상호작용 버튼 활성화
        //FSLocator.controlManager.m_InteractableButton.SetActive(true);

        //대화 관련된 것들 전부 숨기기
		FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
		FSLocator.textDisplayer.reactionButton.gameObject.SetActive (false);
        FSLocator.textDisplayer.HideDialogueHolder();
		//FSLocator.cutSceneTextDisplayer.cutSceneText.gameObject.SetActive (false);;
        //FSLocator.characterDisplayer.HideImage();
        //FSLocator.backgroundDisplayer.HideBackground();

		//TutorialController.Instance.ShowButton ();

        //NPC EVENT ON
        //FSLocator.npcEventMaster.AllNpcEventOn ();

        //퀘스트가 바꼈으면 이벤트 끝날때 바꿔줌
        //FSLocator.onoffQuest.txt.text = FSLocator.questMgr.queststring;

    }
}