using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : UIScript {

    // 아이템 canvas
    public GameObject itemDisplayer;

    // 조합 버튼이 들어있는 bg
    public GameObject mixBg;
    // 주다 버튼이 들어있는 bg
    public GameObject giveBg;

    // Name Text
    public Text itemName;
    // Explanation Text
    public Text itemExp;
    // Item Image
    public Image itemImage;




    // 메인화면 상단 UI의 Icon 클릭으로 인벤토리 캔버스 표시
    public override void OnClickUI()
    {
        // 인벤토리 UI에 주다 버튼이 들어있는 bg가 가려진다.
        giveBg.SetActive(false);
        // 인벤토리 UI에 조합 버튼이 들어있는 bg가 표시된다.
        mixBg.SetActive(true);

        InitUI();
    }
    
    // NPC 대화 상 '주다' 버튼으로 인벤토리 캔버스 표시
    public void OnClickGive()
    {
        // 인벤토리 UI에 주다 버튼이 들어있는 bg가 표시된다.
        giveBg.SetActive(true);
        // 인벤토리 UI에 조합 버튼이 들어있는 bg가 가려진다.
        mixBg.SetActive(false);

        InitUI();
    }

    // 인벤토리 캔버스 종료
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


    // ================================================================== 비공개 메서드 정의 ======================================================
    
    private void InitUI()
    {
        // 기존의 좌측 칸에 클릭 아이템 정보를 지운다.
        itemName.text = "";
        itemExp.text = "";
        itemImage.enabled = false;

        // UI 표시
        itemDisplayer.gameObject.SetActive(true);
    }
}
