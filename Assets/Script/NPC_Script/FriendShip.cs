using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShip : MonoBehaviour {

	public int friendly;
	public FriendShipCondition[] friendShipCondition = new FriendShipCondition[0];

	public void Start(){
		CheckAndSetCondition ();
	}

	public void CheckAndSetCondition()
	{
		for (int i = 0; i < friendShipCondition.Length; i++) {
			if (friendly >= friendShipCondition [i].requireFriendly) {
				friendShipCondition [i].CheckAndFix ();
			}
		}
	}


}
