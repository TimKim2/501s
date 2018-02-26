using UnityEngine;
using System.Collections;
public class ChangeSceneReaction : DelayedReaction
{
	//ChangeSceneManager changeSceneManager;

	protected override void SpecificInit ()
	{
		//TVNTManager.instance.ReferenceTVNTManager (ref changeSceneManager);
	}

	protected override void ImmediateReaction()
	{
		//DataAsset.Instance.isTutorialPrice = true;
		//DataAsset.Instance.SaveData ();
		//changeSceneManager.ChangeSceneToMenu ();
	}
}