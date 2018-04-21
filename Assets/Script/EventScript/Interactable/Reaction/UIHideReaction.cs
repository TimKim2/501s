using UnityEngine;

public class UIHideReaction : DelayedReaction
{
    public GameObject[] UI; 

    protected override void ImmediateReaction()
    {
        foreach (var ui in UI)
            ui.gameObject.SetActive(false);
    }
}
