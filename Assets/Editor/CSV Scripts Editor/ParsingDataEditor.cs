using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ParsingData))]
public class ParsingDataEditor : Editor
{
    // 원본 클래스에 정의되어 있는, 모든 아이템의 정보를 담고 있는 딕셔너리에 접근하기 위한 스크립트
    ParsingData parsingData;
    
    private string itemID = "";
    private string itemName = "";
    private string itemPlace = "";

    private List<Dictionary<string, object>> itemlist = new List<Dictionary<string, object>>();

    void OnEnable()
    {
        // 원본 클래스에 정의되어 있는, 모든 아이템의 정보를 담고 있는 딕셔너리에 접근하기 위한 스크립트 캐싱.
        parsingData = (ParsingData)target;
    }



    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        // Bold로 CSV File Info 표시
        GUILayout.Label("CSV File Info", EditorStyles.boldLabel);
   
        // 들여 쓰고..
        EditorGUI.indentLevel++;

        EditorGUILayout.TextField("CSV FIle Path: ", parsingData.csvAllPath);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("All Item Count : ", parsingData.list.Count.ToString());
        EditorGUILayout.Space();

        // 들여 쓴거 뺴고..
        EditorGUI.indentLevel--;

        // Bold로 CSV File Info 표시
        GUILayout.Label("Item Condition Info", EditorStyles.boldLabel);

        // 들여 쓰고..
        EditorGUI.indentLevel++;

        itemID = EditorGUILayout.TextField("Item ID           : ", itemID);
        itemName = EditorGUILayout.TextField("Item Name      : ", itemName);
        itemPlace = EditorGUILayout.TextField("Item Place       : ", itemPlace);
        EditorGUILayout.Space();

        if (GUILayout.Button("Find Items in Item List by CSV"))
        {
            // ID NAME Place에 맞는 아이템 정보를 표시
            itemlist = parsingData.GetItemsByCondition(itemID, itemName, itemPlace);

            // 근대 이걸 표시하는게 지금 필요한건 아니니 나중에 만듬ㅇㅇ

        }
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        // 들여 쓴거 뺴고..
        EditorGUI.indentLevel--;

        // Bold로 CSV File Info 표시
        GUILayout.Label("Finding Item List", EditorStyles.boldLabel);

        // 들여 쓰고..
        EditorGUI.indentLevel++;

        

        if (EditorGUI.EndChangeCheck())
        {
            //변경전에 Undo 에 등록
            Undo.RecordObject(parsingData, "Change hp");

            

        }
    }
}
