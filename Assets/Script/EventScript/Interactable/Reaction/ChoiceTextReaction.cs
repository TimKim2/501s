using UnityEngine;
using System.Collections;
public class ChoiceTextReaction : DelayedReaction
{
	public string dialogue;
	public string characterName;
	public Sprite characterImage;

	public string firstChoice;
	public string secondChoice;

	public ReactionCollection firstReactionCollection;
	public ReactionCollection secondReactionCollection;

	protected override void SpecificInit()
	{

	}


	protected override void ImmediateReaction()
	{
		Debug.Log (dialogue);
		FSLocator.textDisplayer.choiceFrame.ShowChoiceFrame (firstChoice, secondChoice, firstReactionCollection, secondReactionCollection);
		FSLocator.textDisplayer.Say(dialogue, characterName);
		FSLocator.characterDisplayer.DrawImage(characterImage, characterName);

	}
}