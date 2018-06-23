using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickScript : MonoBehaviour {

    // 플레이어 객체
    private NewPlayer player;

    // ClickArea RectTransform 콤포넌트 캐싱
    private RectTransform rectTrans;

    // ClickArea 초기 위치
    private Vector2 idlePos;
    // ClickArea 최대 이동 길이
    private float maxMove;
    // ClickArea 이동 벡터
    private Vector2 moveVector;


	// Use this for initialization
	void Start () {
        // 플레이어 객체 캐싱
        player = GameObject.Find("Player").GetComponent<NewPlayer>();

        rectTrans = GetComponent<RectTransform>();
        
        // Idle 상태에서(기본 상태에서) ClickArea 위치 캐싱
        idlePos = transform.position;
        // 최대 ClickArea 이동 거리 지정
        maxMove = 25.0f;
	}

    // 드래그
    public void Drag(BaseEventData _Data)
    {
        // 드래그한 위치 정보..
        PointerEventData Data = _Data as PointerEventData;
        // 를 Vector2로 변환
        Vector2 conPos = Data.position;

        // 드래그한 위치가 maxMove보다 작다면 ClickArea 객체는 해당 위치에 있는다.
        if (Vector2.Distance(conPos, idlePos) < maxMove)
        {
            transform.position = conPos;
        }
        // 드래그한 위치가 maxMove보다 크다면 ClickArea 객체는 maxMove 범위 내에 해당 방향에 위치한다.
        else
        {
            // 정규화
            Vector2 normalized = new Vector2(conPos.x - idlePos.x, conPos.y - idlePos.y);
            normalized.Normalize();

            // 크기가 1로 정규화된 normalized를 최대maxMove 의 크기만큼 변환 
           transform.position = idlePos + normalized * maxMove;
        }

        // 정규화한 벡터의 방향으로 플레이어를 이동
        moveVector = new Vector2(conPos.x - idlePos.x, conPos.y - idlePos.y).normalized;
        player.Move(moveVector);
    }

    // 드래그 끝.
    public void DragEnd()
    {
        // 플레이어를 정지
        player.Stop();

        // ClickArea의 위치를 다시 중앙으로 이동
        // idlePos는 Transform 위치를 나타내기때문에 RectTransform인 rectTrans에 대입x
        rectTrans.position = idlePos;

        // 현재 이동 방향이 없으므로 moveVector도 0으로 초기화
        moveVector = Vector2.zero;
    }
}
