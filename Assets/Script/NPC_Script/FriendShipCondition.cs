using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipCondition : ScriptableObject {

	public string description;
	public int requireFriendly = 0;
	public Condition[] addCondition = new Condition[0];

}
