using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    [SerializeField] GameObject settingPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked_settingbutton()
    {
        GameObject[]destroyobj;
        destroyobj = GameObject.FindGameObjectsWithTag("clickeffect");
        for(int i = 0; i < destroyobj.Length;i++)
        {
            Destroy(destroyobj[i]);
        }
        settingPanel.SetActive(true);
        GManager.instance.gamestopflag = true;
        Time.timeScale = 0.0f;
    }

    public void onClicked_closebutton()
    {
        GameObject[] destroyobj;
        destroyobj = GameObject.FindGameObjectsWithTag("clickeffect");
        for (int i = 0; i < destroyobj.Length; i++)
        {
            Destroy(destroyobj[i]);
        }
        settingPanel.SetActive(false);
        GManager.instance.gamestopflag = false;
        Time.timeScale = 1.0f;
    }
}
