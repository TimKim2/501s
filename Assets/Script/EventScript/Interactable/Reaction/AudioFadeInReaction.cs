using UnityEngine;
using System.Collections;

public class AudioFadeInReaction : DelayedReaction
{
	public AudioSource audioSource;
	public AudioClip audioClip;
	[Range(0.0f, 1.0f)]
	public float volume = 0.5f;
	public float maxVolume;
	public float fadeTime;

	GameObject go;

	protected override void ImmediateReaction()
	{
		if (audioClip != null)
			audioSource.clip = audioClip;
		audioSource.volume = volume;
		audioSource.PlayDelayed(delay);
		go = CoroutineHandler.Start_Coroutine(FadeInAudio()).gameObject;
	}

	IEnumerator FadeInAudio()
	{
		while (audioSource.volume < maxVolume)
		{
			audioSource.volume += (Time.deltaTime / fadeTime);

			yield return null;
		}

		audioSource.volume = maxVolume;

		Destroy(go);
	}
}