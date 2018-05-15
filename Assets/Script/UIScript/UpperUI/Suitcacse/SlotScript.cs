using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour {

    // ContentScript로 부터 넘겨지는, 현재 slot에 표시되는 아이템의 ID
    private string ID;

    // 아이템 이미지 캐싱
    private Image itemImage;
    // 아이템 이름 캐싱
    private string itemName = "";
    // 아이템 설명 캐싱
    private string itemExp = "";

    private ItemScript itemScript;


    // slot 기본 데이터 캐싱
    public void InitSlot()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemScript = GameObject.Find("ItemDisplayer").GetComponent<ItemScript>();

        // click 이벤트 연결
        GetComponent<Button>().onClick.AddListener(OnSlotClick);
    }

    // slot 클릭 함수 정의
    public void OnSlotClick()
    {
        // slot contents 좌측 설명, 이름칸에 정보 전달 - 표시
        itemScript.EditClickItemInfo(itemName, itemExp, itemImage);
    }

    // Item 획득 시 호출(sprite는 item의 이미지)
    public void GetItem( string tempID, string tempName, string tempExp)
    {
        // 표시할 이미지 정보 저장
        ID = tempID;
        itemName = tempName;
        itemExp = tempExp;

        // 이미지는 임시로..
        itemImage.sprite = Resources.Load<Sprite>("ArtResource/Paper");

        // slot button target graphic을 변경(변경하지 않으면 click 시 색 변환이 안댐)
        GetComponent<Button>().targetGraphic = itemImage;

        // slot에 얻은 아이템 이미지 표시
        itemImage.enabled = true;
    }
}
