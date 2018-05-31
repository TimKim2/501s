using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour {

    // 2018-05-28 전체적으로 2차 수정 시작
    // 아래의 조합 재료 아이템 목록에서도 이 SlotScript가 사용될 수 있도록 전체적인 code 수정



    // 각 Slot이 인벤토리 아이템 리스트인지. 재료 아이템 리스트인지 확인
    // ITEM : 인벤토리 아이템 리스트
    // MATERIAL : 재료 아이템 리스트
    public enum USE { ITEM, MATERIAL };
    public USE use;

    // 각 slot마다 가지는 고유의 번호
    private int index;

    // ContentScript로 부터 넘겨지는, 현재 slot에 표시되는 아이템의 ID
    private string ID;
    //현재 slot에 표시되는 아이템의 이미지
    private Image itemImage;
    // 현재 slot에 표시되는 아이템의 이름
    private string itemName;
    // 현재 slot에 표시되는 아이템의 설명
    private string itemExp;


    // 조합 불가능한 아이템 표시 이미지
    private Image deActivatedImage;
    // 현재 drag 하는 아이템 표시 이미지
    private Image activatedImage;


    // 전체적으로 Script에서 사용되는 script.
    private ItemScript itemScript;


    // 현재 slot의 아이템을 drag 하고 있는지 식별
    // 모바일 환경에서의 구현에서 drag 하는 객체에 대한 정보를 무한정 전송하기보다 초기의 한번 전송하는것이 낫다 판단하여 식별하도록 이에 대한 변수를 선언
    private bool isDrag;


    // slot 기본 데이터 캐싱
    public void InitSlot(int index)
    {
        // slot 별 고유번호를 슬롯 관리자인 Content에서 지정
        // material slot의 경우 가리키고 있는 item slot의 index를 표시.
        this.index = index;

        // 초기 아이템 정보 캐싱
        ID = "";
        itemImage = transform.GetChild(0).GetComponent<Image>();
        itemName = "";
        itemExp = "";

        // use 열거형 변수가 ITEM일 경우, 조합 가능 유무를 표시할 이미지 캐싱
        deActivatedImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        activatedImage = transform.GetChild(0).GetChild(1).GetComponent<Image>();

        // 전체적으로 Script에서 사용되는 script 캐싱.
        itemScript = GameObject.Find("ItemDisplayer").GetComponent<ItemScript>();

        // 현재 slot의 아이템을 drag 하고 있는지 식별
        isDrag = false;
    }

    // slot 클릭 함수 정의
    public void OnClick(BaseEventData _Data)
    {
        // 클릭한 slot이 비어있으면 아무 작동도 하지 않음.
        if (ID == "")
            return;

        // 클릭한 slot이 속해있는 List가 아이템 리스트이면..
        if (use == USE.ITEM)
        {
            // 좌측에 아이템 정보 표시
            itemScript.EditClickItemInfo(itemName, itemExp, itemImage);
        }
        // 클릭한 slot이 속해있는 List가 재료 리스트이면..
        else
        {
            // No work
        }
    }

    public void OnDrag(BaseEventData _Data)
    {
        // 클릭한 slot이 비어있으면 아무 작동도 하지 않음.
        if (ID == "" || deActivatedImage.enabled == true)
        {
            return;
        }
        // 클릭한 slot에 아이템이 있으면 drag 시작
        else
        {
            // 이 작업은 drag가 시작될 때 한번만 진행.
            if (!isDrag)
            {
                // 클릭한 slot의 이미지를 Drag할 Image 객체에 전달
                itemScript.dragImage.gameObject.GetComponent<Image>().sprite = itemImage.sprite;
                // Drag 되어지는 Image 객체가 보이도록!
                itemScript.dragImage.gameObject.GetComponent<Image>().enabled = true;

                // drag 시작과 동시에, 현재 slot을 표시
                activatedImage.enabled = true;
            }

            isDrag = true;
        }

        // 드래그한 위치 정보..
        PointerEventData Data = _Data as PointerEventData;
        // 를 Vector2로 변환
        Vector2 conPos = Data.position;

        // Drag할 Image 객체를 현재 클릭 좌표로 이동
        itemScript.dragImage.localPosition = new Vector2(conPos.x - itemScript.transform.position.x, conPos.y - itemScript.transform.position.y);
    }

    public void OnDragEnd(BaseEventData _Data)
    {
        // 클릭했던 slot이 비어있으면 아무 작동도 하지 않음.
        if (ID == "")
            return;
   
        // 클릭했던 slot에 아이템이 있으면 drag 종료
        isDrag = false;

        // 클릭했던 slot의 표시를 제거
        activatedImage.enabled = false;

        // Drag 되어지는 Image 객체가 안보이도록!
        itemScript.dragImage.gameObject.GetComponent<Image>().enabled = false;
        // Drag 되어지는 Image 객체 정보 초기화
        itemScript.dragImage.gameObject.GetComponent<Image>().sprite = null;

        // drag를 마친 자리가 조합 영역인 경우
        if (itemScript.gameObject.GetComponent<ContentScript>().GetIsDrag())
        {
            // 클릭했던 slot이 속해있는 List가 아이템 리스트이면..
            if (use == USE.ITEM)
            {
                // 클릭한 slot의 정보를 재료 영역의 content 에 전달하여 표시
                itemScript.gameObject.GetComponent<ContentScript>().RegistMaterial(ID, index, itemImage.sprite);
            }
            // 클릭했던 slot이 속해있는 List가 재료 리스트이면..
            else
            {
                // No work
            }
        }
        // drag를 마친 자리가 조합 영역 바깥인 경우..
        else
        {
            // 클릭했던 slot이 속해있는 List가 아이템 리스트이면..
            if (use == USE.ITEM)
            {
                // No work
            }
            // 클릭했던 slot이 속해있는 List가 재료 리스트이면..
            else
            {
                // 전달되는 index 정보를 가진 slot을 소거하고, 리스트 재배열
                itemScript.gameObject.GetComponent<ContentScript>().DeleteMaterial(index);
            }
        }

    }
    
    // Item 획득 시 호출(sprite는 item의 이미지)
    public void GetItem( string tempID, string tempName, string tempExp, Sprite tempImage)
    {
        // 표시할 이미지 정보 저장
        ID = tempID;
        itemName = tempName;
        itemExp = tempExp;
        // 이미지는 임시로..
        itemImage.sprite = tempImage;

        // slot button target graphic을 변경(변경하지 않으면 click 시 색 변환이 안댐)
        GetComponent<Button>().targetGraphic = itemImage;

        // slot에 얻은 아이템 이미지 표시
        itemImage.enabled = true;
    }

    public void RegistMaterial(string tempID, int tempIndex, Sprite tempImage)
    {
        // 등록한 material 정보 저장
        ID = tempID;
        itemName = "";
        itemExp = "";
        index = tempIndex;
        // 이미지는 임시로..
        itemImage.sprite = tempImage;

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
        index = -1;
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

    // 현재 이 슬롯이 표시하는 조합 불가능한 아이템 표시를 제거
    public void IsMixOKReverse()
    {
        // 슬롯이 비어있으면... 뭐 할거없잖아?
        if (ID == "")
            return;

        deActivatedImage.enabled = false;
    }

    public string GetID()
    {
        return ID;
    }

    public int GetIndex()
    {
        return index;
    }

    public Sprite GetImage()
    {
        return itemImage.sprite;
    }
}
