using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CutSceneStartReaction : DelayedReaction
{
	float currentTime;

	public int fadeTime;
	public CanvasGroup canvas;

	public List<GameObject> activeFalseObjectList;
	public List<GameObject> activeTrueObjectList;

	CoroutineHandler myCoroutine;

    protected override void ImmediateReaction()
    {
		canvas.alpha = 0.0f;
		canvas.gameObject.SetActive (true);
	
		myCoroutine = CoroutineHandler.Start_Coroutine (FadeIn ());
    }

	private IEnumerator FadeIn()
	{
		currentTime = Time.time;

		while (currentTime + fadeTime > Time.time)
		{
			canvas.alpha += (Time.deltaTime / fadeTime);
			yield return null;
		}

		for (int i = 0; i < activeFalseObjectList.Count; i++) {
			activeFalseObjectList [i].SetActive (false);
		}

		for (int i = 0; i < activeTrueObjectList.Count; i++) {
			activeTrueObjectList [i].SetActive (true);
		}

		GameObject go = myCoroutine.gameObject;
		Destroy(go);
	}

}