using UnityEngine;
using UnityEngine.UI;

public class MissionScript : UIScript {

    // Click animation
    private Animation anim;

    // 표시할 UI
    private Text textUI;

    // mission을 참고할 원본.
    // 여기에 적혀있는 mission을 가져와 UI에 표시하는 역활을 합니다.
    private PlayerInfo playerInfo;

    



    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animation>();
        textUI = transform.Find("Text").GetComponent<Text>();

        playerInfo = Resources.Load("PlayerInfo", typeof(ScriptableObject)) as PlayerInfo;
    }

    // Mission UI Click 시 행동 기술
    public override void OnClickUI()
    {
        // UI에 적을 string을 가져와서..
        textUI.text = playerInfo.GetMission();

        // 화면에 표시
        // 절반 이상을 Play 했으면 다시 되돌아가면서 재생
        if (anim["MissionClick"].normalizedTime > 0.5f)
            anim["MissionClick"].speed = -1.0f;
        else
            anim["MissionClick"].speed = 1.0f;

        anim.Play("MissionClick");

    }
}
