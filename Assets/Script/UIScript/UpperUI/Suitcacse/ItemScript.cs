using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : UIScript {

    // 아이템 canvas
    public GameObject itemDisplayer;

    // Name Text
    public Text itemName;
    // Explanation Text
    public Text itemExp;
    // Item Image
    public Image itemImage;




    // 인벤토리 캔버스 표시
    public override void OnClickUI()
    {
        // 기존의 좌측 칸에 클릭 아이템 정보를 지운다.
        itemName.text = "";
        itemExp.text = "";
        itemImage.enabled = false;

        itemDisplayer.gameObject.SetActive(true);
    }

    // 인벤토리 캔버스 delete
    public void OnClickClose()
    {
        itemDisplayer.gameObject.SetActive(false);
    }

    // slot 클릭 시 좌측 칸에 클릭 아이템 정보 표시
    public void EditClickItemInfo(string name, string exp, Image image)
    {
        // 빈 slot을 클릭한 경우 아무것도 하지않음
        if (name == "" || name == "####")
            return;

        itemName.text = name;
        itemExp.text = exp;
        itemImage.sprite = image.sprite;
        itemImage.enabled = true;
    }
}
