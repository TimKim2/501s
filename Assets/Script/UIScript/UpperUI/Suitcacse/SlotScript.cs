using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour {

    // ContentScript로 부터 넘겨지는, 현재 slot에 표시되는 아이템의 ID
    private string ID = "";

    // 아이템 이미지 캐싱
    private Image itemImage;
    // 아이템 이름 캐싱
    private string itemName = "";
    // 아이템 설명 캐싱
    private string itemExp = "";

    private ItemScript itemScript;

    // 조합 불가능한 아이템 표시 이미지
    private Image deActivatedImage;


    // slot 기본 데이터 캐싱
    public void InitSlot()
    {
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemScript = GameObject.Find("ItemDisplayer").GetComponent<ItemScript>();

        deActivatedImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();

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

    // item 사용 시 호출
    public void DeleteItem()
    {
        // 저장한 정보 삭제
        ID = "";
        itemName = "";
        itemExp = "";
        itemImage.sprite = null;

        // slot button target graphic을 변경(변경하지 않으면 빈 칸 클릭 시 색 변환이 안댐)
        GetComponent<Button>().targetGraphic = GetComponent<Image>();

        // slot에 표시되는 이미지 이제 없으니 표시 x
        itemImage.enabled = false;
    }

    // 현재 이 슬롯에 표시되는 물건이 조합에 사용할 수 있는 물건인지 확인
    public void IsMixOK()
    {
        // 슬롯이 비어있으면... 뭐 할거없잖아?
        if (ID == "")
            return;

        // 이 슬롯에 들어있는 item의 물건이 조합 가능 불가능하다면 deActivatedImage를 표시
        if (itemScript.gameObject.GetComponent<ContentScript>().allData.GetMixByID(ID) == "X")
        {
            deActivatedImage.enabled = true;
        }
    }
}
