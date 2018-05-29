using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : UIScript {

    // 아이템 canvas
    public GameObject itemDisplayer;

    // 현재 표시되고 있는 bg 상태 체크 변수 - Drag and Drop 가능한 bg 확인 등의 작업을 위해 열거형 변수로 확인.
    enum BGSTATE { MIX1, MIX2, GIVE};
    BGSTATE bgState;
    // 조합 버튼이 들어있는 bg
    public GameObject mixBg1;
    // 조합 버튼 클릭 이후 나오는 bg
    public GameObject mixBg2;
    // 주다 버튼이 들어있는 bg
    public GameObject giveBg;


    // Name Text
    public Text itemName;
    // Explanation Text
    public Text itemExp;
    // Item Image
    public Image itemImage;


    // Drag Item Image RectTransform 콤포넌트 캐싱
    public RectTransform dragImage;


    // 메인화면 상단 UI의 Icon 클릭으로 인벤토리 캔버스 표시
    public override void OnClickUI()
    {
        // 인벤토리 UI에 조합 버튼이 들어있는 bg가 표시된다.
        mixBg1.SetActive(true);
        // 인벤토리 UI에 조합 목록 bg가 가려진다.
        mixBg2.SetActive(false);
        // 인벤토리 UI에 주다 버튼이 들어있는 bg가 가려진다.
        giveBg.SetActive(false);

        bgState = BGSTATE.MIX1;

        // 조합 불가능한 아이템을 표시하고 있다면, 이 표시를 제거
        GetComponent<ContentScript>().IsMixOKReverse();

        InitUI();
    }

    // 첫 UI에서 조합 버튼 클릭으로 조합을 할 수 있는 UI로 변환
    public void OnClickMix1()
    {
        // 인벤토리 UI에 조합 버튼이 들어있는 bg가 가려진다.
        mixBg1.SetActive(false);
        // 인벤토리 UI에 조합 목록 bg가 표시진다.
        mixBg2.SetActive(true);
        // 인벤토리 UI에 주다 버튼이 들어있는 bg가 가려진다.
        giveBg.SetActive(false);

        bgState = BGSTATE.MIX2;

        // 자~ 가지고 있는 이이템 목록을 순회하며 조합 가능한 아이템만 표시
        GetComponent<ContentScript>().IsMixOK();

    }

    // drag 하여 모인 아이템들을 조합
    public void OnClickMix2()
    {

    }

    // NPC 대화 상 '주다' 버튼으로 인벤토리 캔버스 표시
    public void OnClickGive()
    {
        // 인벤토리 UI에 조합 버튼이 들어있는 bg가 가려진다.
        mixBg1.SetActive(false);
        // 인벤토리 UI에 조합 목록 bg가 가려진다.
        mixBg2.SetActive(false);
        // 인벤토리 UI에 주다 버튼이 들어있는 bg가 표시된다.
        giveBg.SetActive(true);

        bgState = BGSTATE.GIVE;
        
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
