using UnityEngine;
using UnityEngine.EventSystems;

public class raycast : MonoBehaviour {

    // 플레이어 객체
    private PlayerScript player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update () {
        // 클릭 시..
	    if(Input.GetMouseButtonDown(0))
        {
			Debug.Log ("Click");

            // 클릭 좌표를 확인
            Vector3 touchPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			//Debug.Log (EventSystem.current.currentSelectedGameObject.name);
		

            // 클릭한 항목이 UI가 아니면..
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                // 오브젝트를 클릭한 경우, 해당 오브젝트를 캐싱
                // 근대 우리 게임에 UI 제외 오브젝트 클릭이 존재하나?
                // Ray2D ray = new Ray2D(touchPoint, Vector2.zero);
                // RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);


                // 적당한 속도로 클릭위치까지 이동
                player.Move(touchPoint, 3.5f);

            }
            else
            {
                // 이동 정지
                player.Stop();
            }
        }
	}
}
