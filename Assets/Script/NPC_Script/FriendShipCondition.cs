﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipCondition : ScriptableObject {

	public string description;
	public int requireFriendly = 0;
	public Condition[] addCondition = new Condition[0];

	public void CheckAndFix()
	{
		for (int i = 0; i < addCondition.Length; i++) {

			AllConditions.CheckConditionAndSet (addCondition[i]);
		}
	}

}
