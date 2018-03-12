using UnityEngine;


public class VibrateReaction : DelayedReaction
{
	protected override void ImmediateReaction()
	{
		Debug.Log ("Vive");
		#if UNITY_ANDROID
		Handheld.Vibrate();
		#endif
		Debug.Log ("Vive");
	}
}