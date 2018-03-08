using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CutSceneEndReaction : DelayedReaction
{
	float currentTime;

	public int fadeTime;
	public CanvasGroup canvas;

	public List<GameObject> activeFalseObjectList;
	public List<GameObject> activeTrueObjectList;

	GameObject myCorotine;

	protected override void ImmediateReaction()
	{
		myCorotine = CoroutineHandler.Start_Coroutine (FadeOut ()).gameObject;
	}

	private IEnumerator FadeOut()
	{
		currentTime = Time.time;

		while (currentTime + fadeTime > Time.time)
		{
			canvas.alpha -= (Time.deltaTime / fadeTime);
			yield return null;
		}

		canvas.gameObject.SetActive (false);

		for (int i = 0; i < activeFalseObjectList.Count; i++) {
			activeFalseObjectList [i].SetActive (false);
		}
		for (int i = 0; i < activeTrueObjectList.Count; i++) {
			activeTrueObjectList [i].SetActive (true);
		}
			
		Destroy(myCorotine);
	}
}