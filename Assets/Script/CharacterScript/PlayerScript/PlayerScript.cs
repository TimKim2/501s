using UnityEngine;



public class PlayerScript : CharacterScript {

    // 현재 이동할 목적지 좌표
    Vector2 movePoint;

    // 현재 이동 중인지 체크
    bool isMoving = false;

    // 이동속도
    private float speed;




    // ******************************* 메서드 정의 **********************************





    // Use this for initialization
    // CharacterSript를 상속하는 모든 클래스가 아닌, PlayerScript에서 필요한 Start 본문을 템플릿 메서드 패턴을 이용하여 작성합니다.
    public override void TemplateStart()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 이동
        Moving();
    }


    // 유저가 클릭한 좌표를 플레이어 스크립트에 전달합니다.
    public override void Move(Vector2 touchPoint, float speed)
    {
        // 이동 목표 좌표를 터치 좌표로 지정
        movePoint = touchPoint;
        // 이동 목표 좌표까지 이동할 속도 지정
        this.speed = speed;

        // 이동 시작
        isMoving = true;

        // 이동 애니메이션 수행
        ChangeAnimation();
    }

    // 이동 중이면 목표 좌표로 이동합니다.
    private void Moving()
    {
        if (isMoving)
        {
            // 현재 좌표가 이동 목표 좌표로 이동 완료되면..
            if (trans.position.x == movePoint.x && trans.position.y == movePoint.y)
            {
                // 이동 정지
                isMoving = false;

                // 정지 애니메이션 수행
                ChangeAnimation();

                return;
            }


            // 이동 목표 좌표로 이동 시작
            // y축에 따라 캐릭터들 간의 표시 순서가 달라져야 하므로, y축의 값을 z에도 주면서 sort 되도록 한다.
            trans.position = Vector3.MoveTowards(trans.position, new Vector3(movePoint.x, movePoint.y, movePoint.y), speed * Time.deltaTime);
        }
    }

    // 현재 상황에 맞는 애니메이션을 재생합니다.
    private void ChangeAnimation()
    {
        // 터치 후 이동중이라면..
        if (isMoving)
        {
            // 클릭 좌표가 플레이어보다 왼쪽에 있다.
            if(trans.position.x > movePoint.x)
            {
                 // 클릭 좌표가 플레이어보다 아래에 있다.
                if (trans.position.y > movePoint.y)
                    anim.SetTrigger("BotLeft");
                // 클릭 좌표가 플레이어보다 위에 있다.
                else
                    anim.SetTrigger("TopLeft");

            }
            // 클릭 좌표가 플레이어보다 오른쪽에 있다.
            else
            {
                // 클릭 좌표가 플레이어보다 아래에 있다.
                if (trans.position.y > movePoint.y)
                    anim.SetTrigger("BotRight");
                // 클릭 좌표가 플레이어보다 위에 있다.
                else
                    anim.SetTrigger("TopRight");
            }
        }
        // 정지한 상태이면..
        else
        {
            // 바로 Idle 애니메이션 실행
            anim.SetTrigger("Idle");
        }
    }
}