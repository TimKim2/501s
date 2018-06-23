using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemReaction : DelayedReaction
{
    // 플레이어가 가지는 Item의 ID
    public string itemID;

    private ContentScript playerInventory;

	public GameObject itemObject;

    protected override void ImmediateReaction()
    {
        playerInventory = GameObject.Find("ItemDisplayer").GetComponent<ContentScript>();
		//During Set Item Number
        playerInventory.GetItem(itemID);

		if (itemObject != null)
			Destroy (itemObject);
    }
}
