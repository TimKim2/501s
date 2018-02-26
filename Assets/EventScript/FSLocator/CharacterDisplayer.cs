using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplayer : MonoBehaviour {

    private float dissolveTime = 0.3f;
    public Image characterBodyImage;

    public CanvasGroup characterCanvasGroup;

    Vector3 markScale = new Vector3(1f, 1f, 1f);
    Vector3 stacyScale = new Vector3(0.85f, 1f, 1f);
    Vector3 irineScale = new Vector3(1f, 1f, 1f);
    Vector3 isabelScale = new Vector3(1.22f, 1f, 1f);
    Vector3 timScale = new Vector3(1f, 1f, 1f);
    Vector3 LinScale = new Vector3(1.65f, 1f, 1f);
    Vector3 DaveScale = new Vector3(1f, 1f, 1f);
    Vector3 defaultScale = new Vector3(1f, 1f, 1f);
    
    public void HideImage()
    {
        ImediateStopTransition();
        StartCoroutine("Hide");
    }


    public void DrawImage(Sprite sprite, string name)
    {
		characterBodyImage.gameObject.SetActive (true);

        characterBodyImage.sprite = sprite;
        if (name == "FireCat")
        {
            characterBodyImage.transform.localScale = markScale;
        }
        else if(name == "스테이시")
        {
            characterBodyImage.transform.localScale = stacyScale;
        }
        else if (name == "아이린")
        {
            characterBodyImage.transform.localScale = irineScale;
        }
        else if (name == "이사벨")
        {
            characterBodyImage.transform.localScale = isabelScale;
        }
        else if (name == "팀")
        {
            characterBodyImage.transform.localScale = timScale;
        }
        else if (name == "린차오")
        {
            characterBodyImage.transform.localScale = LinScale;
        }
        else if (name == "데이브")
        {
            characterBodyImage.transform.localScale = DaveScale;
        }
        else
        {
            characterBodyImage.transform.localScale = defaultScale;
        }
        ImediateStopTransition();
        if(sprite)
            StartCoroutine("Show");
        else
            characterCanvasGroup.alpha = 0.0f;
    }



    private void ImediateStopTransition()
    {
        StopCoroutine("Show");
        StopCoroutine("Hide");
    }

    private IEnumerator Show()
    {
        characterCanvasGroup.alpha = 0.0f;
        
       
        float startTime = Time.time;

        while (Time.time <= startTime + dissolveTime)
        {
            characterCanvasGroup.alpha += (Time.deltaTime / dissolveTime);
            yield return null;
        }

        characterCanvasGroup.alpha = 1.0f;
    }

    private IEnumerator Hide()
    {
        //characterCanvasGroup.alpha = 1.0f;
        float startTime = Time.time;

        while (Time.time <= startTime + dissolveTime)
        {
            characterCanvasGroup.alpha -= (Time.deltaTime / dissolveTime);
            yield return null;
        }

        characterCanvasGroup.alpha = 0.0f;
    }
}
