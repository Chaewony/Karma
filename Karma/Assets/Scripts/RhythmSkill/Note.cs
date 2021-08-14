using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0.2f+0.5f)  //노트가 작아짐
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0) * noteSpeed * Time.deltaTime;
        }
    }
}
