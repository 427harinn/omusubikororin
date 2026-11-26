using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsuduraPractice : MonoBehaviour
{
    public TextSend textsend;
    [SerializeField] GameObject TsuduraImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void onClicked_TsuduraButton()
    {
        this.gameObject.SetActive(false);
        TsuduraImage.SetActive(true);
        if(textsend.textfinishflag == false)
        {
            textsend.gimmick = false;
        } else
        {
            textsend.Nextbuttonactive();
        }
    }
}
