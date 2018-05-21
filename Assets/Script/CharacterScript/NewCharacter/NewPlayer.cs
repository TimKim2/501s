using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayer : NewCharacter{

    // 이동할 Vector
    private Vector2 moveVector;

    // 코루틴 목록 - 솔직히 지금은 이동밖에 코루틴을 사용하지 않아서 굳이 이래야 하나 싶기도 하다..
    // 만약 특정 이벤트에서 이 객체에 코루틴을 작용하면, 기존에 작동되는 코루틴과 충돌이 일어날 수 있으므로,
    // 기존에 작동되는(평상시에 작동되는) 모든 코루틴을 관리할 수 있어야 한다.
    private List<IEnumerator> coroutineList;

    // =========================================== 공개 메서드 ============================================

    // Use this for initialization
    protected override void TemplateStart()
    {
        isMoving = false;
        moveVector = Vector2.zero;

        coroutineList = new List<IEnumerator>();

        IEnumerator co1 = Moving();
        coroutineList.Add(co1);
        // 앞으로 추가되는 코루틴을 여기서 추가

        // 코루틴 시작
        CoroutineListStart();
    }


    // 외부에서 (아마 대부분 조이스틱 스크립트) 플레이어로 전달하는 이동 정보에 대한 함수
    public void Move(Vector3 moveVector)
    {
        this.moveVector = moveVector;
        isMoving = true;
    }

    // 외부에서 (아마 대부분 조이스틱 스크립트) 플레이어로 전달하는 정지 정보에 대한 함수
    public void Stop()
    {
        isMoving = false;
        this.moveVector = Vector3.zero;

        // 애니메이션 정지
        ChangeAnimation();
    }


    // =========================================== 비공개 메서드 ============================================

    // 기존에 작동하는 모든 코루틴을 다시 start
    protected override void CoroutineListStart()
    {
        foreach(IEnumerator e in coroutineList)
        {
            StartCoroutine(e);
        }
    }


    // 기존에 작동하는 모든 코루틴을 stop
    protected override void CoroutineListStop()
    {
        foreach (IEnumerator e in coroutineList)
        {
            StopCoroutine(e);
        }
    }


    // 이동 코루틴
    private IEnumerator Moving()
    {
        while (true)
        {
            // 만약 이동 중이면..
            if (isMoving)
            {
                // 방향에 따른 애니메이션 변환
                ChangeAnimation();

                // 방향으로 이동
                MoveToVector(moveVector);
            }
            yield return null;
        }
    }


    // 이전에 작용되고 있던 애니메이션을 표시 - 같은 애니메이션이 계속 호출 되는것을 방지, 4방향의 Idle 중 어느 방향을 호출할 지 선택
    private enum BEHAVIOR_MODE { IDLE, MOVE_TOPLEFT, MOVE_TOPRIGHT, MOVE_BOTLEFT, MOVE_BOTRIGHT };
    private BEHAVIOR_MODE beforeDir = BEHAVIOR_MODE.IDLE;

    // 현재 상황에 맞는 애니메이션을 재생합니다.
    private void ChangeAnimation()
    {
        // 이동 애니메이션
        if(isMoving)
        {
            // 오른쪽
            if(moveVector.x >0)
            {
                // 위
                if (moveVector.y > 0)
                {
                    if (beforeDir != BEHAVIOR_MODE.MOVE_TOPRIGHT)
                    {
                        anim.SetTrigger("TopRight");

                        beforeDir = BEHAVIOR_MODE.MOVE_TOPRIGHT;
                    }
                }
                // 아래
                else
                {
                    if (beforeDir != BEHAVIOR_MODE.MOVE_BOTRIGHT)
                    {
                        anim.SetTrigger("BotRight");

                        beforeDir = BEHAVIOR_MODE.MOVE_BOTRIGHT;
                    }
                }
            }
            // 왼쪽
            else
            {
                // 위
                if (moveVector.y > 0)
                {
                    if (beforeDir != BEHAVIOR_MODE.MOVE_TOPLEFT)
                    {
                        anim.SetTrigger("TopLeft");

                        beforeDir = BEHAVIOR_MODE.MOVE_TOPLEFT;
                    }
                }
                // 아래
                else
                {
                    if (beforeDir != BEHAVIOR_MODE.MOVE_BOTLEFT)
                    {
                        anim.SetTrigger("BotLeft");

                        beforeDir = BEHAVIOR_MODE.MOVE_BOTLEFT;
                    }
                }
            }
        }
        // 정지 애니메이션
        else
        {
            switch(beforeDir)
            {
                case BEHAVIOR_MODE.MOVE_BOTLEFT:
                    anim.SetTrigger("Idle_BotLeft");
                    break;
                case BEHAVIOR_MODE.MOVE_BOTRIGHT:
                    anim.SetTrigger("Idle_BotRight");
                    break;
                case BEHAVIOR_MODE.MOVE_TOPLEFT:
                    anim.SetTrigger("Idle_TopLeft");
                    break;
                case BEHAVIOR_MODE.MOVE_TOPRIGHT:
                    anim.SetTrigger("Idle_TopRight");
                    break;
            }
            beforeDir = BEHAVIOR_MODE.IDLE;
        }
    }
}
