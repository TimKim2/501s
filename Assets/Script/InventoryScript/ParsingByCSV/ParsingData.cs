using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParsingData : ScriptableObject {

    // 속성 정의에서, 접근 범위를 private로 하면 editor 상에서 호출 시간이 길어져서 전체적인 성능이 많이 떨어진다고 함.
    // 뭐 어차피 Inspector 창에 넣을 스크립트도 아니니까 접근 범위를 public으로 한다.

    // csv 파일 절대 경로 (Inspector 창 표시 경로)
    public string csvAllPath = "";

    // Resource 파일 내부의 csv 파일 경로 (실제 csv 파싱 경로)
    public string csvFilePath = "";

    // csv로부터 파싱한 정보를 캐싱할 변수.
    public List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();



    //================================================= 공개 메서드 정의 =======================================================//

    // csv 파일 경로를 받아 파싱한다.
    public void CreateAssetInfo(string path)
    {
        // csv 파일 경로를 설정한다.
        SetFilePath(path);

        // 해당 경로의 csv 파일로부터 정보를 읽어들여 파싱한다.
        Parsing();
    }

    // 해당 ID, ItemName, ItemPlace에 맞는 Itme들만 가져온다.
    public List<Dictionary<string, object>> GetItemsByCondition(string itemID, string itemName, string itemPlace)
    {
        bool atFirst = false;

        // 해당 조건에 맞는 item들만 추가할 리스트
        List< Dictionary<string, object>> item = new List<Dictionary<string, object>>();

        // ID 조건
        if(itemID != "")
        {
            atFirst = true;

            for(int i=0; i< list.Count; i++)
            {
                if (list[i]["ID"] as string == itemID)
                    item.Add(list[i]);
            }
        }
        // Name 조건
        if(atFirst)
        {
            if (itemName != "")
            {
                for (int i = 0; i < item.Count; i++)
                {
                    if (list[i]["NAME"] as string != itemName)
                        item.Remove(list[i]);
                }
            }
        }
        else
        {
            atFirst = true;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]["NAME"] as string == itemName)
                    item.Add(list[i]);
            }
        }
        // Place 조건
        if (atFirst)
        {
            if (itemPlace != "")
            {
                for (int i = 0; i < item.Count; i++)
                {
                    if (list[i]["PLACE"] as string != itemPlace)
                        item.Remove(list[i]);
                }
            }
        }
        else
        {
            atFirst = true;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i]["PLACE"] as string == itemPlace)
                    item.Add(list[i]);
            }
        }
        
        return item;
    }

    //================================================ 비공개 메서드 정의 ======================================================//



    // File 
    private void SetFilePath(string path)
    {
        csvAllPath = path;
        csvFilePath = path;

        int n = csvFilePath.LastIndexOf("Resources");
        if (n != -1)
        {
            // 현재 경로에서 Resource/ 부분을 제거
            int pathFirst = n + "Resource/".Length + 1;
            // 현재 경로에서 .csv 부분을 제거
            int pathLast = csvFilePath.Length - pathFirst - 4;

            csvFilePath = csvFilePath.Substring(pathFirst, pathLast);
        }
    }

    // csv 파일로부터 파싱하여 딕셔너리에 넣는다.
    private void Parsing()
    {
        // 기존의 리스트를 비운다.
        list.Clear();

        // 새로 데이터 파싱
        list = CSVReader.Read(csvFilePath);
    }
}
