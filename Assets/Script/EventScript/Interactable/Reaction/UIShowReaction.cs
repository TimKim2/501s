using UnityEngine;

public class UIShowReaction : DelayedReaction
{

    public GameObject[] UI;

    protected override void ImmediateReaction()
    {
        foreach (var ui in UI)
            ui.gameObject.SetActive(true);
    }
}
