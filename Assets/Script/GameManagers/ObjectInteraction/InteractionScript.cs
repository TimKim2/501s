using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionScript : MonoBehaviour {

    // HUD UI를 표시하는 canvas
    private Transform canvas;

    // UI를 표시하는 NPC 객체
    private Transform parentObject;

    // NPC 객체가 가지는 UI 목록
    public List<Button> list;
	public ReactionCollection reaction;

    private List<Button> conShowedUI = new List<Button>();

    private void Start()
    {
        canvas = GameObject.Find("HUD_Canvas").GetComponent<Transform>();

        parentObject = gameObject.transform.parent;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 상호작용이 가능한 거리로 플레이어가 접근
        if(collision.tag == "Player")
        {
            // 지정된 UI 리스트에서 리스트 한개를 추출 (위치는 현재 무시..)
            foreach(var ui in list)
            {

                // 해당 UI 프리팹을 생성
                Button button = Instantiate(ui, transform.position, transform.rotation);

                // 현재 생성된 UI를 목록에 저장
                conShowedUI.Add(button);

                // 생성한 UI를 Canvas 하위로 이동
                button.transform.SetParent(canvas);

                // 생성한 UI 위치를 부모 객체 위로 이동
                button.GetComponent<RectTransform>().anchoredPosition = new Vector2(parentObject.position.x, parentObject.position.y + 1.8f);

				button.onClick.RemoveAllListeners ();
				button.onClick.AddListener(delegate {
					reaction.React();
				});

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 상호작용이 불가능한 거리로 플레이어가 이동
        if (collision.tag == "Player")
        {
            // 현재 표시된 UI들을 제거
            foreach (var ui in conShowedUI)
            {
                Destroy(ui.gameObject);
            }
            // 현재 표시된 UI가 없으므로 할당했던 리스트를 초기화한다.
            conShowedUI.Clear();
        }
    }
}
