using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseClick_info : MonoBehaviour
{



    Sprite[] mouses;
    Sprite deadmouse;

    public TextSend textsend;


    public bool flashing = true;
    // Start is called before the first frame update
    void Start()
    {
        mouses = Resources.LoadAll<Sprite>("Character/nezumi_down");
        deadmouse = mouses[2];
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void onClicked_mouse()
    {
        flashing = false;
        this.gameObject.transform.GetChild(0).GetComponent<Image>().sprite = deadmouse;
        this.gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
        textsend.Nextbuttonactive();
    }
}
