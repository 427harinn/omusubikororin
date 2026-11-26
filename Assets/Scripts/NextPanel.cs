using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour
{
    bool clicked = false;
    bool stopflag = false;
    GameObject obj;
    GameObject turnobj;
    // Start is called before the first frame update
    void Start()
    {
        turnobj = this.gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (clicked)
        {
            // transform‚ğæ“¾
            Transform myTransform = obj.transform;
            // Œ»İ‚ÌÀ•W‚©‚ç‚Ìxyz ‚ğ1‚¸‚Â‰ÁZ‚µ‚ÄˆÚ“®
            myTransform.Translate(0, 0.2f, 0, Space.World);
            


            if (!stopflag)
            {
                stopflag = true;
                Invoke("Panelstop", 1);
            }

        }
    }

    public void nextbutton_onClicked()
    {
        if(GManager.instance.activepanel != 22)
        {
            if (!clicked)
            {
                turnobj.SetActive(false);
                clicked = true;
                stopflag = false;
                obj = GameObject.Find("Panel" + GManager.instance.activepanel);
            }
        }

    }

    private void Panelstop()
    {
        turnobj.SetActive(true);
        GManager.instance.activepanel++;
        Destroy(obj);
        this.gameObject.SetActive(false);
        clicked = false;
    }
}
