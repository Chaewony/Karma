using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//알파값 변경 예제 스크립트
public class FadeOut : MonoBehaviour
{
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;

        if (color.a < 1)
        {
            color.a += Time.deltaTime;
        }
        image.color = color;
    }
}