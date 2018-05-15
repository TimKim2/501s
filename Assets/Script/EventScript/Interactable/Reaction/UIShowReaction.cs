using UnityEngine;

public class UIShowReaction : DelayedReaction
{
    private UICaching uiCaching;

    protected override void ImmediateReaction()
    {
        uiCaching = GameObject.Find("UpperUI").GetComponent<UICaching>();

        foreach (var ui in uiCaching.GetUI())
            ui.gameObject.SetActive(true);
    }
}