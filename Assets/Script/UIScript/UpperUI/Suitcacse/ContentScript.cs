using UnityEngine;
using UnityEngine.EventSystems;

public class ContentScript : MonoBehaviour {

    // 2018-05-28 전체적으로 2차 수정 시작
    // 조합 기능 추가에 따라, 이 스크립트를 조합 - 아이템 리스트 모든 경우에서 사용할 수 있도록 수정.

    // 아이템 slot을 담고있는 content 객체
    public GameObject itemContent;
    // 아이템 리스트의 전체 slot
    private SlotScript[] itemSlots;
    // 아이템 리스트의 현재 채워져 있는 slot 갯수
    private int conSlot_item = 0;

    
    // 재료 slot을 담고있는 content 객체
    public GameObject materialContent;
    // 재료 리스트의 전체 slot
    private SlotScript[] materialSlots;
    // 재료 리스트의 현재 채워져 있는 slot 갯수
    private int conSlot_material = 0;


    // 현재 drag로 조합 창으로 물건을 가져왔는지 체크
    private bool isDrag = false;


    // csv 파일에서 파싱한, 전체 아이템에 대한 정보
    [HideInInspector] public ParsingData allData;


    // ========================================================== 공개 메서드 정의 ====================================================

    // Item 획득 시 호출(ID는 item의 csv 파일 내 ID 값)
    public void GetItem(string ID, Sprite tempImage)
    {
        // 비워져 있는 item 칸이 있는지 확인
        if (conSlot_item >= itemSlots.Length)
        {
            // 허용 가능한 아이템 획득 갯수를 초과하였다,

            return;
        }
        else
        {
            string tempName = GetName(ID);
            string tempExp = GetExplanation(ID);

            // slot에 아이템 정보를 전송
            itemSlots[conSlot_item].GetItem(ID, tempName, tempExp, tempImage);

            // 현재 채워져 있는 slot 갯수 변경
            conSlot_item++;
        }
    }

    // item slot의 아이템을 material slot으로 이동 시 호출
    public void RegistMaterial(string ID, int index, Sprite tempImage)
    {
        // 비워져 있는 item 칸이 있는지 확인
        if (conSlot_material >= materialSlots.Length)
        {
            // 허용 가능한 재료 등록 갯수를 초과하였다,

            return;
        }
        else
        {
            // 만약 등록하려는 item slot의 아이템이 이미 재료로 등록되어 있다면 등록을 거부
            foreach(SlotScript slot in materialSlots)
            {
                if (slot.GetIndex() == index)
                    return;
            }

            // slot에 재료 정보를 전송
            materialSlots[conSlot_material].RegistMaterial(ID, index, tempImage);

            // 현재 채워져 있는 material 갯수 변경
            conSlot_material++;
        }
    }

    // 모든 material slot을 비운다.
    public void DeleteAllMaterial()
    {
        // 전체 material slot의 삭제는 뒤 쪽 slot부터 삭제를 해야 무의미한 sort 과정이 무시된다.
        for(int i = conSlot_material - 1; i >= 0; i--)
        {
            DeleteMaterial(i);
        }
    }

    // 해당 index 정보를 가지는 material slot을 비운다.
    public void DeleteMaterial(int index)
    {
        // 삭제 index를 찾은 이전과 이후를 확인할 변수
        // 이 변수가 true가 되면서부터 sort를 시작
        bool sortTrigger = false;

        for(int i = 0; i < conSlot_material; i++)
        {
            // 현재 material list의 재료들의 index와 전달받은 index를 비교
            if (materialSlots[i].GetIndex() == index)
            {
                // material list 중 가장 마지막 항이 삭제되는 재료일 경우..
                if (i == conSlot_material - 1)
                {
                    // 해당 재료의 정보를 바로 지우고..
                    materialSlots[i].DeleteItem();

                    // 현재 재료의 수를 변경하고
                    conSlot_material--;
                    // 종료
                    return;
                }
                // 그 외, 즉 중간의 material slot의 재료를 삭제하는 경우..
                else
                {
                    // 정렬 시작
                    sortTrigger = true;
                }
            }

            // 정렬이 시작되면..
            if(sortTrigger)
            {
                // 마지막 항까지 정렬을 수행..
                if(i == conSlot_material - 1)
                {
                    // 마지막 항은 삭제만 수행
                    materialSlots[i].DeleteItem();
                }
                else
                {
                    // 마지막 전까지는 현재 노드에 다음 노드의 정보를 대입
                    materialSlots[i].RegistMaterial(materialSlots[i + 1].GetID(), materialSlots[i + 1].GetIndex(), materialSlots[i + 1].GetImage());
                }
            }
        }
        //현재 재료의 수를 변경
        conSlot_material--;
    }

    // 현재 가지고 있는 아이템 목록 중 조합이 불가능한 아이템 표시
    public void IsMixOK()
    {
        // 각 slot 마다 가지고 있는 물건이 조합 가능한지 판별
        // slot이 비어있으면 아무 작동 x
        foreach (SlotScript slot in itemSlots)
            slot.IsMixOK();
    }


    // 조합 불가능한 아이템 표시를 제거
    public void IsMixOKReverse()
    {
        foreach(SlotScript slot in itemSlots)
        {
            slot.IsMixOKReverse();
        }
    }

    // 조합 하려는 item을 조합 창으로 들고 왔는지 판별
    public void Enter()
    {
        isDrag = true;
    }

    // 조합 하려는 item을 조합 창으로 들고 왔는지 판별
    public void Exit()
    {
        isDrag = false;
    }

    public bool GetIsDrag()
    {
        return isDrag;
    }
    
    // ========================================================== 비공개 메서드 정의 ====================================================

    private void Start()
    {
        // 아이템 리스트에 대한 각 변수들을 할당
        Transform trans = itemContent.transform;
        itemSlots = new SlotScript[trans.childCount];
        for (int num = 0; num< trans.childCount; num++)
        {
            itemSlots[num] = trans.GetChild(num).gameObject.GetComponent<SlotScript>();
            itemSlots[num].InitSlot(num);
        }


        // 재료 리스트에 대한 각 변수들을 할당
        trans = materialContent.transform;
        materialSlots = new SlotScript[trans.childCount];
        for(int num = 0; num < trans.childCount; num++)
        {
            materialSlots[num] = trans.GetChild(num).gameObject.GetComponent<SlotScript>();
            materialSlots[num].InitSlot(-1);
        }


        // All Item List scriptable object 캐싱
        allData = Resources.Load("CSVData/All Item List Asset") as ParsingData;
    }

    // 전체 아이템 목록의 scriptable object 에서 해당 IO에 해당하는 item의 이름 반환
    private string GetName(string ID)
    {
        Debug.Log (allData.GetNameByID(ID));
        return allData.GetNameByID(ID);
    }

    // 전체 아이템 목록의 scriptable object 에서 해당 IO에 해당하는 itee의 설명 반환
    private string GetExplanation(string ID)
    {
        Debug.Log(allData.GetExplanationByID(ID));
        return allData.GetExplanationByID(ID);
    }
}
