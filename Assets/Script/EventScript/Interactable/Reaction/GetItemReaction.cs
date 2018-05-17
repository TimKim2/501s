using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemReaction : DelayedReaction
{
    public string itemID;
    private ContentScript playerInventory;

    protected override void ImmediateReaction()
    {
        playerInventory = GameObject.Find("ItemDisplayer").GetComponent<ContentScript>();
        playerInventory.GetItem(itemID);
    }
}
