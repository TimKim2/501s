using UnityEngine;
using UnityEngine.EventSystems;

public class raycast : MonoBehaviour {

    // 플레이어 객체
    private PlayerScript player;

    // 더블 클릭으로 인정되는 최대 시간
    private float doubleClick = 0.25f;
    // 클릭한 시간
    private float beforeClick = 0.0f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update () {
        // 클릭 시..
	    if(Input.GetMouseButtonDown(0))
        {
            // 클릭한 항목이 UI가 아니면..
            if(EventSystem.current.IsPointerOverGameObject() == false)
            {
                // 클릭 좌표를 확인
                Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // 오브젝트를 클릭한 경우, 해당 오브젝트를 캐싱
                // 근대 우리 게임에 UI 제외 오브젝트 클릭이 존재하나?
                // Ray2D ray = new Ray2D(touchPoint, Vector2.zero);
                // RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


                // 만약 더블클릭을 했다면..
                if (Time.time - beforeClick < doubleClick)
                {
                    // 빠른 속도로 클릭위치까지 이동
                    player.Move(touchPoint, 5.0f);
                }
                // 더블클릭이 아니면..
                else
                {
                    // 적당한 속도로 클릭위치까지 이동
                    player.Move(touchPoint, 3.0f);
                }
                // 이전에 클릭한 시간을 현재 시간으로 갱신합니다.
                beforeClick = Time.time;
            }
        }
	}
}
