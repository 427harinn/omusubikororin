using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TsuduraUp : MonoBehaviour
{

    private Camera mainCamera;             //メインカメラ取得
    private float initiatePosY;              //最初のY座標
    private float initiatePosX;              //最初のX座標

    public TextSend textsend;

    public bool moving;

    private bool clear;

    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        initiatePosX = transform.position.x;
        initiatePosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        fade();
    }

    private void OnMouseDrag()
    {

        if ((this.gameObject.transform.parent.name == "Panel" + GManager.instance.activepanel) && !GManager.instance.gamestopflag)
        {
            if (effect)
            {
                Destroy(effect);
            }
            //マウスのポジションを取得してピースZ座標を代入しておく
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.y >= initiatePosY)
            {
                moving = true;
                this.gameObject.transform.GetChild(0).GetComponent<Image>().enabled = true;
                this.gameObject.transform.GetChild(1).GetComponent<Image>().enabled = true;
                mousePos.x = initiatePosX;
                //ドラッグ中のピースにマウス座標を代入する
                transform.position = mousePos;
            }
            else if (mousePos.y < initiatePosY)
            {
                Vector2 returnPos;
                returnPos.y = initiatePosY;
                returnPos.x = initiatePosX;
                transform.position = returnPos;
            }

            if (transform.position.y >= 2.1f && textsend.textfinishflag)
            {
                clear = true;
                Destroy(this.gameObject, 0.5f);
                textsend.gimmick = false;
            }
        }

    }

    private void OnMouseExit()
    {
        moving = false;
    }

    float alfa = 1;
    private void fade()
    {
        if (clear == true)
        {
            alfa -= 0.01f;
            this.gameObject.GetComponent<Image>().color = new Color(1,1,1,alfa);
            this.gameObject.transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, alfa);
            this.gameObject.transform.GetChild(1).GetComponent<Image>().color = new Color(1, 1, 1, alfa);
        }
    }
}
