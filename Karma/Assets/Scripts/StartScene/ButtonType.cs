using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonType : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public buttonType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    public FadeEffect fadeEffect;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnButtonClick()
    {
        switch(currentType)
        {
            case buttonType.Start:
                fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));
                Invoke("LoadForest", 2); //2초 뒤 맵 로드
                break;
            case buttonType.Quit:
                fadeEffect.StartCoroutine(fadeEffect.Fade(0, 1));
                Invoke("LoadQuit", 2); //2초 뒤 맵 로드
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) //스크립트가 붙어있는 오브젝트에 마우스가 닿으면 이 함수가 호출됨
    {
        buttonScale.localScale = defaultScale * 1.03f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
    
    //////////////////////////////////////////////////////////////////////////
   
    public void LoadForest()
    {
        SceneManager.LoadScene("Forest");
    }
    public void LoadQuit()
    {
        Application.Quit();
    }
}
