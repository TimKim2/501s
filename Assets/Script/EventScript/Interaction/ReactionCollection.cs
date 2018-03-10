using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReactionCollection : MonoBehaviour
{
    public Reaction[] reactions = new Reaction[0];

    private int startIndex = 0;
    [HideInInspector]
    public float delaytime;

    private void Start()
    {
        for (int i = 0; i < reactions.Length; i++)
        {
            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

            if (delayedReaction)
                delayedReaction.Init();
            else
                reactions[i].Init();
        }
    }

	public void InitIndex()
	{
		startIndex = 0;

		for (int i = 0; i < reactions.Length; i++)
		{
			DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

			if (delayedReaction)
				delayedReaction.Init();
			else
				reactions[i].Init();
		}

		FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
	}


    public void React()
    {
		Debug.Log ("Click");

        if (FSLocator.textDisplayer.isTyping)
        {
            FSLocator.textDisplayer.SkipTypingLetter();
			FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
			FSLocator.textDisplayer.reactionButton.onClick.AddListener(delegate { this.React(); });
            return;
        }
        
        for (int i = startIndex; i < reactions.Length; i++)
        {
           	Debug.Log(i);

            DelayedReaction delayedReaction = reactions[i] as DelayedReaction;

			Debug.Log (reactions [i].GetType ().Name);

            if (delayedReaction)
            {
                if (reactions[i].GetType().Name == "TextReaction")
                {
					if (startIndex == reactions.Length - 1) {
						Debug.Log ("Break");
						break;
					}
                    else
                    {
                        startIndex = i + 1;
                        delayedReaction.React(this);
						FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
						FSLocator.textDisplayer.reactionButton.onClick.AddListener(delegate { this.React(); });
						Debug.Log ("Add Delegate");
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "DelayReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;

						FSLocator.textDisplayer.reactionButton.onClick.RemoveAllListeners();
						FSLocator.textDisplayer.reactionButton.onClick.AddListener(delegate { this.React(); });

						delayedReaction.React(this);
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "AnimationReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        //FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        //FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        delayedReaction.React(this);
                        return;
                    }
                }

                else if (reactions[i].GetType().Name == "AnimationDesReaction")
                {
                    if (startIndex == reactions.Length - 1)
                        break;
                    else
                    {
                        startIndex = i + 1;
                        //FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                        //FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                        delayedReaction.React(this);
                        return;
                    }
                }
                else if (reactions[i].GetType().Name == "EventCallbackReaction" || reactions[i].GetType().Name == "EventCallbackConditionReaction")
                {
                    startIndex = 0;
                   // Debug.Log("Event Callback");
                    delayedReaction.React(this);
                    return;
                }
                else if (reactions[i].GetType().Name == "SkipReaction")
                {
                    Skip();
                    //FSLocator.controlManager.m_Button.onClick.RemoveAllListeners();
                    //FSLocator.controlManager.m_Button.onClick.AddListener(delegate { this.React(); });
                    //return;
                }
                else
                {
                  	Debug.Log("Other Reaction");
                    delayedReaction.React(this);
                }
            }
            else
            {
                
            }
        }
        //startIndex = 0;

    }

	public void Skip()
	{
		for (int i = startIndex; i < reactions.Length; i++)
		{
			if (reactions[i].GetType().Name == "AnimationReaction")
			{
				//AnimationReaction animationReaction = reactions[i] as AnimationReaction;
				//animationReaction.Skip ();
			}

        }

	}

	public void MoveAround()
	{
		reactions[0].React(this);
	}
  
}
