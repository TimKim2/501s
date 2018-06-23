using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionChangeReaction : DelayedReaction {

    // 지정할 Mission
    public string mission;

    protected override void ImmediateReaction()
    {
        // asset에 전달받은 mission 저장
        PlayerInfo saveAsset = Resources.Load("PlayerInfo", typeof(ScriptableObject)) as PlayerInfo;
        saveAsset.SetMission(mission);
    }
}
