using UnityEngine;

public class UIHideReaction : DelayedReaction
{
    private UICaching uiCaching;

    protected override void ImmediateReaction()
    {
        uiCaching = GameObject.Find("UpperUI").GetComponent<UICaching>();

        foreach (var ui in uiCaching.GetUI())
            ui.gameObject.SetActive(false);
    }
}
