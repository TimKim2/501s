using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTextReaction : DelayedReaction
{
    public string Text_1;
	public string Text_2;
	public string Text_3;
  

    protected override void ImmediateReaction()
    {
		//TutorialController.Instance.SetCutSceneText_1 (Text_1);
		//TutorialController.Instance.SetCutSceneText_2 (Text_2);
		//TutorialController.Instance.SetCutSceneText_3 (Text_3);
    }
}
