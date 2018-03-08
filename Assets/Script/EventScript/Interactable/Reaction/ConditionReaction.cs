using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionReaction : DelayedReaction {

	public Condition condition;

	protected override void SpecificInit ()
	{
		
	}

	protected override void ImmediateReaction()
	{
		condition.satisfied = true;
	}
}
