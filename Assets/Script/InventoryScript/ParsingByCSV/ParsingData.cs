﻿using System.Collections;
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

    // csv 파일이 어느 종류의 정보를 보관하는지 식별
    // 각 종류마다 호출 가능한 함수가 다르므로, 불가능한 함수의 호출을 방지
    public enum CSV_TYPE
    {
        Item_Info,
        Mix_Info,
    }
    public CSV_TYPE type;



    //================================================= 공개 메서드 정의 =======================================================//

    public void OnEnable()
    {
        //SetFilePath(path);
        Parsing();
    }

    // csv 파일 경로를 받아 파싱한다.
    public void CreateAssetInfo(string path)
    {
        // csv 파일 경로를 설정한다.
        SetFilePath(path);
        // 해당 경로의 csv 파일로부터 정보를 읽어들여 파싱한다.
        Parsing();
    }

    // ID의 item에 해당하는 NAME 노드 값
    public string GetNameByID(string itemID)
    {
        // 이 함수는 CSV 파일의 Type이 Item_Info에서만 호출되어야 합니다.
        if (type == CSV_TYPE.Mix_Info)
        {
            Debug.Log("Can't this Function!");
            return "";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]["ID"] as string == itemID)
                return list[i]["NAME"] as string;
        }

        Debug.Log("No Name Value!!");
        return "No Name!!";
    }

    // Name의 Item에 해당하는 ID 노드 값
    public string GetIDByName(string itemName)
    {
        // 이 함수는 CSV 파일의 Type이 Item_Info에서만 호출되어야 합니다.
        if (type == CSV_TYPE.Mix_Info)
        {
            Debug.Log("Can't this Function!");
            return "";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]["NAME"] as string == itemName)
                return list[i]["ID"] as string;
        }

        Debug.Log("No ID Value!!");
        return "No ID!!";
    }

    // ID의 item에 해당하는 EXPLANATION 노드 값
    public string GetExplanationByID(string itemID)
    {
        // 이 함수는 CSV 파일의 Type이 Item_Info에서만 호출되어야 합니다.
        // 솔직히 Asset 해버리고 싶지만 참는다.
        if (type == CSV_TYPE.Mix_Info)
        {
            Debug.Log("Can't this Function!");
            return "";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]["ID"] as string == itemID)
                return list[i]["EXPLANATION"] as string;
        }

        Debug.Log("No Explanation Value!!");
        return "No Explanation!!";
    }

    // ID의 item에 해당하는 MIX 노드 값
    public string GetMixByID(string itemID)
    {
        // 이 함수는 CSV 파일의 Type이 Item_Info에서만 호출되어야 합니다.
        // 솔직히 Asset 해버리고 싶지만 참는다.
        if (type == CSV_TYPE.Mix_Info)
        {
            Debug.Log("Can't this Function!");
            return "";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]["ID"] as string == itemID)
                return list[i]["MIX"] as string;
        }

        Debug.Log("No Mix Value!!");
        return "No Mix Value!!";
    }

    // ID의 Sprite 이미지의 이름(파일속에 붙여진 이름)을 반환
    public string GetSpriteByID(string itemID)
    {
        // 이 함수는 CSV 파일의 Type이 Item_Info에서만 호출되어야 합니다.
        // 솔직히 Asset 해버리고 싶지만 참는다.
        if (type == CSV_TYPE.Mix_Info)
        {
            Debug.Log("Can't this Function!");
            return "";
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i]["ID"] as string == itemID)
                return list[i]["SPRITE"] as string;
        }
        Debug.Log("No Sprite Value!!");
        return "No Sprite Value!!";
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
        // Scriptable object 객체가 만들어지면, 처음에 무조건 enable 함수가 호출되는듯 함.
        // CreateAssetInfo 함수 내부에서 csv 파일과 연결을 맺는데, 그 전에 자동적으로 호출되는 enable에서 csv 파싱에 접근하면서 에러가 발생한 듯.
        // 따라서 초기 csvFilePath가 지정되지 않은 상태의 Parsing 함수 호출을 막으면 에러가 발생하지 않음.
        if (csvFilePath == "" || csvFilePath == null)
            return;

        // 기존의 리스트를 비운다.
        list.Clear();

        // 새로 데이터 파싱
        list = CSVReader.Read(csvFilePath);
    }
}
