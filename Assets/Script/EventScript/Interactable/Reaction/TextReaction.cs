using UnityEngine;

public class TextReaction : DelayedReaction
{
    public string dialogue;
    public string characterName;
    public Sprite characterImage;


    protected override void SpecificInit()
    {
      
    }


    protected override void ImmediateReaction()
    {
		Debug.Log (dialogue);
        FSLocator.textDisplayer.Say(dialogue, characterName);
        FSLocator.characterDisplayer.DrawImage(characterImage, characterName);
    }
}