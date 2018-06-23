using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemReaction : DelayedReaction
{
    public string itemID;
    public Sprite itempImage;

    private ContentScript playerInventory;

	public GameObject itemObject;

    protected override void ImmediateReaction()
    {
        playerInventory = GameObject.Find("ItemDisplayer").GetComponent<ContentScript>();
		//During Set Item Number
        playerInventory.GetItem(itemID, itempImage);

		if (itemObject != null)
			Destroy (itemObject);
    }
}
