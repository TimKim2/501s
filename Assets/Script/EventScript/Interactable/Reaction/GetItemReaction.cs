using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemReaction : DelayedReaction
{
    public string itemID;
    public ContentScript test;

    protected override void ImmediateReaction()
    {
        test.GetItem(itemID);
    }
}
