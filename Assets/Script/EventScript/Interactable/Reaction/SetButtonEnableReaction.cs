﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SetButtonEnableReaction : DelayedReaction
{
	public Button button;
	public bool isEnable;

	protected override void SpecificInit()
	{

	}

	protected override void ImmediateReaction()
	{
		Debug.Log (isEnable + "isEnable");
		button.enabled = isEnable;
	}
}