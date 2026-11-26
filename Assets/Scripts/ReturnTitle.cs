using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnTitle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked_returntitlebutton()
    {
        GManager.instance.activepanel = 0;
        GManager.instance.gamestopflag = false;
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");

    }
}
