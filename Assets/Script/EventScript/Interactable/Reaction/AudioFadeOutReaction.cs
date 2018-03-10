using UnityEngine;
using System.Collections;

public class AudioFadeOutReaction : DelayedReaction
{
	public AudioSource audioSource;
	public AudioClip audioClip;
	[Range(0.0f, 1.0f)]
	public float volume = 0.5f;
	public float fadeTime;

	GameObject go;

	protected override void ImmediateReaction()
	{
		if (audioClip != null)
			audioSource.clip = audioClip;
		
		audioSource.volume = volume;
		//audioSource.PlayDelayed(delay);
		go = CoroutineHandler.Start_Coroutine(FadeOutAudio()).gameObject;
	}

	IEnumerator FadeOutAudio()
	{
		while (audioSource.volume > 0)
		{
			audioSource.volume -= volume * (Time.deltaTime / fadeTime);

			yield return null;
		}

		audioSource.Stop();


		Destroy(go);
	}
}