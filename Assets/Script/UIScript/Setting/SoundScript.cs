using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundScript : MonoBehaviour {

    // 환경설정 canvas
    public GameObject settingDisplayer;

    // 사운드 canvas
    public GameObject soundDisplayer;


    // Background Speaker 옆 빼뺴로들
    public Image bSound1, bSound2, bSound3;
    // Background Slider
    public Slider bSlider;
    // Background 소리 정보
    private AudioSource bSource;

    // Effect Speaker 옆 뺴뺴로들
    public Image eSound1, eSound2, eSound3;
    // Effect Slider
    public Slider eSlider;
    // Effect 소리 정보
    private AudioSource eSource;



    private void Start()
    {
        // 0.6의 소리를 낸다.
        // 소리 정보도 asset으로 보존하여 게임을 실행 중 에서 씬을 변경해도 소리 크기가 변하지 않도록 해야하나, 지금은 뭐... 그냥 합시다!
        bSound1.enabled = true;
        bSound2.enabled = true;
        bSound3.enabled = false;
        bSource = GameObject.Find("BGM").GetComponent<AudioSource>();
        bSource.volume = 0.6f;
        bSlider.value = 0.6f;

        eSound1.enabled = true;
        eSound2.enabled = true;
        eSound3.enabled = false;
        eSource = GameObject.Find("EffectSound").GetComponent<AudioSource>();
        eSource.volume = 0.6f;
        eSlider.value = 0.6f;
    }

    // Background 소리 Slider를 이동 시 호출
    public void OnbSoundChanged(Slider slider)
    {
        // 소리를 키우거나 줄이고

        // speaker 이미지 옆의 빼빼로들 수정해야징
        float temp = slider.value;

        if (temp == 0)
        {
            bSound1.enabled = false;
            bSound2.enabled = false;
            bSound3.enabled = false;
        }
        else if (temp < 0.3f)
        {
            bSound1.enabled = true;
            bSound2.enabled = false;
            bSound3.enabled = false;
        }
        else if (temp < 0.6f)
        {
            bSound1.enabled = true;
            bSound2.enabled = true;
            bSound3.enabled = false;
        }
        else
        {
            bSound1.enabled = true;
            bSound2.enabled = true;
            bSound3.enabled = true;
        }
        bSource.volume = temp;
    }

    // Effect 소리 Slider를 이동 시 호출
    public void OneSoundChanged(Slider slider)
    {
        // 소리를 키우거나 줄이고

        // speaker 이미지 옆의 빼빼로들 수정해야징
        float temp = slider.value;

        if (temp == 0)
        {
            eSound1.enabled = false;
            eSound2.enabled = false;
            eSound3.enabled = false;
        }
        else if (temp < 0.3f)
        {
            eSound1.enabled = true;
            eSound2.enabled = false;
            eSound3.enabled = false;
        }
        else if (temp < 0.6f)
        {
            eSound1.enabled = true;
            eSound2.enabled = true;
            eSound3.enabled = false;
        }
        else
        {
            eSound1.enabled = true;
            eSound2.enabled = true;
            eSound3.enabled = true;
        }
        eSource.volume = temp;
    }

    // close 버튼 클릭
    public void OnClickClose()
    {
        soundDisplayer.gameObject.SetActive(false);
    }

    // back 버튼 클릭
    public void OnClickBack()
    {
        soundDisplayer.gameObject.SetActive(false);

        settingDisplayer.gameObject.SetActive(true);
    }
}
