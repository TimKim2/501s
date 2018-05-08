using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcScript : CharacterScript {

    // NPC가 가지는 행동 패턴
    // IDLE : 현재 위치에서 대기한다.
    // MOVE : 초기 위치에서 지정된 위치로 이동
    // EVENT : 특정 위치로 이동하며, 이벤트가 끝나기 전에는 IDLE_MOVE가 작동되지 않는다. 
    private enum BEHAVIOR_MODE {IDLE, MOVE, EVENT};
    private BEHAVIOR_MODE mode;

    // 이동속도
    private float speed = 1.5f;

    // ******************************* 메서드 정의 **********************************





    // Use this for initialization
    // CharacterSript를 상속하는 모든 클래스가 아닌, PlayerScript에서 필요한 Start 본문을 템플릿 메서드 패턴을 이용하여 작성합니다.
    public override void TemplateStart()
    {

    }

    // 해당 좌표로 이동하는 함수
    public override void Move(Vector2 movePoint, float speed)
    {
        // 이동 코루틴 시작
        StartCoroutine(Moving(movePoint));
    }
    
    private IEnumerator Moving(Vector2 movePoint)
    {
        // Event 실행 중 이동이 발생한다면, 아직 Event가 종료되지 않았으므로 mode 변경x
        if (mode == BEHAVIOR_MODE.EVENT)
        { }
        else
        {
            // 현재 행동모드를 변경
            mode = BEHAVIOR_MODE.MOVE;
        }

        // Move 애니메이션 실행

        // 목적지에 도착할 때 까지 이동
        while (!(trans.position.x == movePoint.x && trans.position.y == movePoint.y))
        {
            // 해당 좌표로 이동
            trans.position = Vector3.MoveTowards(trans.position, new Vector3(movePoint.x, movePoint.y, movePoint.y), speed * Time.deltaTime);
            yield return null;
        }
    }

    public void Idle(float restTime)
    {
        // 대기 코루틴 시작
        StartCoroutine(Idling(restTime));
    }

    private IEnumerator Idling(float restTime)
    {
        // Event 실행 중 이동이 발생한다면, 아직 Event가 종료되지 않았으므로 mode 변경x
        if (mode == BEHAVIOR_MODE.EVENT)
        { }
        else
        {
            // 현재 행동모드를 변경
            mode = BEHAVIOR_MODE.IDLE;
        }

        // Idle 애니메이션 실행

        // 애니메이션 상태에서 대기
        yield return new WaitForSeconds(restTime);
    }

    public void EventStart()
    {
        mode = BEHAVIOR_MODE.EVENT;
    }

    public void EventEnd()
    {
        mode = BEHAVIOR_MODE.IDLE;
    }

    // ===============================================================현재 사용 안하는 메소드들=============================================================

    // 플레이어가 NPC 인지 구역 안으로 진입하면, 해당 NPC는 플레이어를 쳐다봅니다.
    public void NearByPlayer()
    {
        // 만약 NPC가 어떤 이벤트 중간에 플리에어와 가까워진다면, 해당 이벤트를 유지해야 하므로 함수를 진행하지 않습니다.
        // ex) 플레이어와 NPC가 같이 어느 장소로 이동되는 스크립티를 수행중이면, 그 동안 NPC와 플레이어가 충분히 가까워져도 이 함수가 실행되면 안됩니다.
        if(mode != BEHAVIOR_MODE.EVENT)
        {
            // 현재 진행중인 코루틴을 멈춥니다.
            StopAllCoroutines();

            // 플레이어를 본다.
        }
    }

    // 플레이어가 NPC 인지 구역 밖으로 멀어지면, 해당 NPC는 다시 기존의 행동을 이어갑니다.
    public void GetAwayPlayer()
    {
        // 이벤트와 관련되지 않은.. 즉, 평범하게 행동하는 상황이면..
        if (mode != BEHAVIOR_MODE.EVENT)
        {
            // 하던 행동을 마저 수행
            StartCoroutineByMode();
        }
    }

    // 현재 NPC의 mode에 해당하는 코루틴 실행
    // 이후 mode의 수가 많아질 수 있으므로 따로 실행하는 함수를 구현
    private void StartCoroutineByMode()
    {
        switch (mode)
        {
            case BEHAVIOR_MODE.IDLE:

                break;
            case BEHAVIOR_MODE.MOVE:

                break;
            case BEHAVIOR_MODE.EVENT:
                
                break;
        }
    }
}
