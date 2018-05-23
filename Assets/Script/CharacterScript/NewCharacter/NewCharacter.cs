using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NewCharacter : MonoBehaviour {

    // 현재 객체의 Transform 콤포넌트
    protected Transform trans;

    // 현재 객체의 Animator 콤포넌트
    protected Animator anim;

    // 현재 객체의 Rigidbody2D 콤포넌트
    protected Rigidbody2D rig2D;

    // 현재 객체가 이동중인가?
    protected bool isMoving = false;

    // 현재 객체츼 이동 속도
    private float speed = 2.5f;

    // =========================================== 공개 메서드 ============================================

    // CharacterSript를 상속하는 클래스의 Start() 메서드에서 재정의할 내용들을 여기에 작성합니다.
    // Start 메서드는 캐릭터 객체의 Information을 캐싱하므로 재정의하면 안됩니다.
    protected abstract void TemplateStart();

    // 이동 메서드 등 코루틴으로 작성되는 함수들을 start 하는 함수
    protected abstract void CoroutineListStart();

    // 이동 메서드 등 코루틴으로 작성되는 함수들을 stop 하는 함수
    protected abstract void CoroutineListStop();


    // 현재 객체의 위치를 전달받은 좌표로 즉시 이동
    // 플레이어 or NPC의 캐릭터가 특정 위치로 이동되는 이벤트를 위해 구현
    public void MoveToPositionImmediately(Vector3 des)
    {
        trans.position = des;
    }


    // 현재 객체의 위치를 전달받은 좌표로 이동
    // 플레이어 or NPC의 캐릭터가 특정 위치로 걸어서 이동하는 이벤트를 위해 구현
    public void MoveToPositionBywork(Vector3 des)
    {
        // 만약 여러 Character 들이 동시에 이동할 수 있으므로 코루틴을 이용, 동시적인 이동을 구현
        StartCoroutine(MoveToDestination(des));
    }


    // 현재 플레이어의 이동은 조이스틱을 이용한 이동이다.
    // 따라서 좌표가 아닌, 전달받은 벡터 방향으로 이동하는 메서드도 필요하다.
    public void MoveToVector(Vector3 vector)
    {
        //trans.Translate(vector * *Time.deltaTime  speed);
        rig2D.velocity = vector * speed;

        trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.y);
    }


    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }


    public float GetSpeed()
    {
        return speed;
    }

    // =========================================== 비공개 메서드 ============================================

    // Use this for initialization
    void Start()
    {
        // 현재 객체의 Transform 콤포넌트 캐싱
        trans = GetComponent<Transform>();
        // 현재 객체의 Animator 콤포넌트 캐싱
        anim = GetComponent<Animator>();
        // 현재 객체의 Rigidbody2D 콤포넌트 캐싱
        rig2D = GetComponent<Rigidbody2D>();

        // CharacterSript를 상속하는 클래스에서 Start() 메서드를 사용하면 위의 콤포넌트 캐싱이 가려진다.
        // CharacterSript를 상속하는 클래스의 Start() 메서드에서 사용할 내용들을 템플릿 메서드 패턴으로 대체한다.
        TemplateStart();
    }


    private IEnumerator MoveToDestination(Vector2 movePoint)
    {
        // 기존에 작동되고 있는 다른 코루틴을 모두 stop 한다.
        CoroutineListStart();

        isMoving = true;

        while (!(trans.position.x == movePoint.x || trans.position.y == movePoint.y))
        {
            trans.position = Vector3.MoveTowards(trans.position, new Vector3(movePoint.x, movePoint.y, movePoint.y), speed * Time.deltaTime);
            trans.position = new Vector3(trans.position.x, trans.position.y, trans.position.y);
            yield return null;
        }

        isMoving = false;

        // stop한 기존의 코루틴을 다시 start 한다.
        CoroutineListStop();
    }
}
