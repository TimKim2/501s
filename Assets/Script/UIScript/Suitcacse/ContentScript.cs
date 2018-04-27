﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentScript : MonoBehaviour {

    // 현재 채워져 있는 slot 갯수
    private int conSlot = 0;
    private int maxSlot;

    // slot을 담고있는 content 객체
    public GameObject content;
    // 전체 slot
    private GameObject[] slots;

    // 전체 아이템에 대한 정보
    public ParsingData allData;


    // ========================================================== 공개 메서드 정의 ====================================================

    // Item 획득 시 호출(ID는 item의 csv 파일 내 ID 값)
    public void GetItem(string ID)
    {
        // 비워져 있는 item 칸이 있는지 확인
        if (conSlot >= slots.Length)
        {
            // 근대 칸이 40개인데... 그럴일은 없겠지..

        }
        else
        {
            string tempName = GetName(ID);
            string tempExp = GetExplanation(ID);

            // slot에 아이템 정보를 전송
            slots[conSlot].GetComponent<SlotScript>().GetItem(ID, tempName, tempExp);

            // 현재 채워져 있는 slot 갯수 변경
            conSlot++;
        }
    }

    // ========================================================== 비공개 메서드 정의 ====================================================

    private void Start()
    {
        Transform trans = content.transform;
        maxSlot = trans.childCount;

        slots = new GameObject[maxSlot];
        for (int num = 0; num< maxSlot; num++)
        {
            slots[num] = trans.GetChild(num).gameObject;
            slots[num].GetComponent<SlotScript>().InitSlot();
        }
    }

    private string GetName(string ID)
    {
        Debug.Log (allData.GetNameByID(ID));
        return allData.GetNameByID(ID);
    }
    private string GetExplanation(string ID)
    {
        Debug.Log(allData.GetExplanationByID(ID));
        return allData.GetExplanationByID(ID);
    }
}
