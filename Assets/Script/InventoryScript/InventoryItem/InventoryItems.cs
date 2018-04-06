using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu]
public class InventoryItems : ScriptableObject
{
    // 현재 가지고 있는 아이템 리스트
    // string : 가지고 있는 아이템의 ID
    public List<string> items = new List<string>();

    // 전체 아이템 정보를 가지고 있는 Scriptable object의 객체
    // 아이템 추가/제거에 아이템의 ID를 사용하기에 해당 ID를 비교할 원본 데이터가 있어야 하며, 이 클래스가 데이터를 유지한다.
    public ParsingData parsingData;

    // asset 경로
    private string assetPath = "Assets/Resources/InvectoryData/InventoryItemList.asset";

    //================================================= 공개 메서드 정의 =======================================================//

    // 아이템 추가
    public List<string> AddItem(string itemID)
    {
        // 아이템 추가 본문 실행
        Adding(itemID);

        // 인벤토리 scriptable object asset 갱신
        UpdateAsset();

        return items;
    }

    // 아이템 제거
    public List<string> DeleteItem(string itemID)
    {
        // 아이템 삭제 본문 실행
        Deleting(itemID);

        // 인벤토리 scriptable object asset 갱신
        UpdateAsset();

        return items;
    }

    // 아이템 목록 소거
    public List<string> ClearList()
    {
        // 아이템 목록 소거 본문 실행
        Clearing();

        // 인벤토리 scriptable object asset 갱신
        UpdateAsset();

        return items;
    }

    //================================================ 비공개 메서드 정의 ======================================================//

    // 아이템 추가/제거 후 Asset 정보 갱신
    private void UpdateAsset()
    {
        // asset 정보를 담을 인스턴스 생성
        var instance = CreateInstance<InventoryItems>();
        
        // 객체 정보를 담은 인스턴스 asset 형식으로 저장
        AssetDatabase.CreateAsset(instance, assetPath);
        AssetDatabase.Refresh();
    }

    // 아이템 추가 본문
    private void Adding(string itemID)
    {
        // 해당 ID가 존재하는지 확인할 플래그 변수
        bool exist = false;

        // 해당 ID에 해당하는 아이템이 있는지 확인
        for (int i = 0; i < parsingData.list.Count; i++)
        {
            if (parsingData.list[i]["ID"] as string == itemID)
            {
                exist = true;
                break;
            }
        }

        // 존재하면..
        if (exist)
        {
            // 추가
            items.Add(itemID);
        }
        else
        {
            // 상황 설명
            Debug.Log(itemID + " : 이상한 ID가 입력되었습니다.");
        }
    }

    // 아이템 삭제 본문
    private void Deleting(string itemID)
    {
        // 해당 ID가 현재 인벤토리 목록에 존재하는지 확인할 플래그 변수
        bool exist = false;

        // 해당 ID에 해당하는 아이템이 있는지 확인
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == itemID)
            {
                exist = true;
                break;
            }
        }

        // 존재하면..
        if (exist)
        {
            // 삭제
            items.Remove(itemID);
        }
        else
        {
            // 상황 설명
            Debug.Log(itemID + " : 이상한 ID가 입력되었습니다.");
        }
    }

    // 리스트 소거 본문
    public void Clearing()
    {
        items.Clear();
    }
}