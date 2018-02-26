using UnityEngine;

public class TutorialTextReaction : DelayedReaction
{
	public string dialogue;
	public int m_fadeTime = 2;

	protected override void SpecificInit()
	{

	}


	protected override void ImmediateReaction()
	{
		float currentTime = Time.time;

		//Color color = TutorialController.Instance.tutorialText.color;
		//color.a = 0.0f;

		//TutorialController.Instance.tutorialText.color = color;

		//TutorialController.Instance.tutorialText.text = dialogue;
		//TutorialController.Instance.tutorialText.gameObject.SetActive (true);

		/*
		while (currentTime + m_fadeTime > Time.time)
		{
			color.a += (Time.deltaTime / m_fadeTime);
			TutorialController.Instance.tutorialText.color = color;

		}
		*/


	}


}