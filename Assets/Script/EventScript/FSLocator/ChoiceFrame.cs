using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceFrame : MonoBehaviour {

	public Text firstText;
	public Text secondText;

	public Button firstButton;
	public Button secondButton;

	public void ShowChoiceFrame(string firstText, string secondText, ReactionCollection firstReaction, ReactionCollection secondReaction){
		gameObject.SetActive (true);
		this.firstText.text = firstText;
		this.secondText.text = secondText;

		firstButton.onClick.AddListener(delegate{
			firstReaction.InitAndReact();
			transform.parent.GetComponent<TextDisplayer>().reactionButton.onClick.AddListener(delegate {
				firstReaction.React();
			});
			HideChoiceFrame();
		});
		secondButton.onClick.AddListener (delegate {
			secondReaction.InitAndReact ();
			transform.parent.GetComponent<TextDisplayer>().reactionButton.onClick.AddListener(delegate {
				secondReaction.React();
			});
			HideChoiceFrame();
		});

	}

	public void HideChoiceFrame(){

		firstButton.onClick.RemoveAllListeners ();
		secondButton.onClick.RemoveAllListeners ();



		gameObject.SetActive (false);
	}
}
