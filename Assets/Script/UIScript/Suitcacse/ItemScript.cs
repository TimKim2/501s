using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : UIScript {

    // 아이템 canvas
    public GameObject itemDisplayer;

    // Use this for initialization
    void Start () {
		
	}

    public override void OnClickUI()
    {
        itemDisplayer.gameObject.SetActive(true);
    }

    public void OnClickClose()
    {
        itemDisplayer.gameObject.SetActive(false);
    }
}
