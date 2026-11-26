using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick : MonoBehaviour
{



    Sprite[]mouses;
    Sprite deadmouse;

    int deadcount;

    public TextSend textsend;

    public GameObject[]mousebutton;

    public bool[]flashing = new bool[3];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < flashing.Length;i++)
        {
            flashing[i] = true;
        }
        mouses = Resources.LoadAll<Sprite>("Character/nezumi_down");
        deadmouse = mouses[2];
    }

    // Update is called once per frame
    void Update()
    {
 


        if(deadcount == 3)
        {
            textsend.gimmick = false;
        }
    }

    public void onClicked_mouse(int i)
    {
        Debug.Log("‰Ÿ‚¹‚½"+ i);
        if (flashing[i])
        {
            deadcount++;
            flashing[i] = false;
        }
        mousebutton[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
        mousebutton[i].transform.GetChild(0).GetComponent<Image>().sprite = deadmouse;
    }
}
