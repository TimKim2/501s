using UnityEngine;


public class VibrateReaction : Reaction
{
	protected override void ImmediateReaction()
	{
		#if UNITY_ANDROID
		Handheld.Vibrate();
		#endif
	}
}