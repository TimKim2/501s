using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipCondition : ScriptableObject {

	public string description;
	int requireFriendly;
	public Condition[] addCondition = new Condition[0];

}
