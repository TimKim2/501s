using UnityEngine;

public class AudioReaction : DelayedReaction
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    [Range(0.0f, 1.0f)]
    public float volume = 0.5f;

    protected override void ImmediateReaction()
    {
        audioSource.clip = audioClip;
        audioSource.volume = volume;
        audioSource.PlayDelayed(delay);
    }
}