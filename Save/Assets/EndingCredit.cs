using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadStart", 80);
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("Start");
    }
}
