using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplayer : MonoBehaviour {

    private float dissolveTime = 0.3f;
    public Image characterBodyImage;

    public CanvasGroup characterCanvasGroup;

  
    
    public void HideImage()
    {
        ImediateStopTransition();
        StartCoroutine("Hide");
    }


    public void DrawImage(Sprite sprite, string name)
    {
		characterBodyImage.gameObject.SetActive (true);

        characterBodyImage.sprite = sprite;
        
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
