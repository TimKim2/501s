using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject {

    // Mission UI Click에 나오는 string
    private string mission;

    // 현재 인벤토리에 저장되어있는 값
    private List<string> inventory;



    // -------------------------------------------------------------------- Mission 관련 Function ------------------------------------------------------------------

	public void SetMission(string tempMission)
    {
        mission = tempMission;
    }

    public string GetMission()
    {
        return mission;
    }








    // -------------------------------------------------------------------- Inventory 관련 Function ------------------------------------------------------------------





}
