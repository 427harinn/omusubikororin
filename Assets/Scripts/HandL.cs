using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandL : MonoBehaviour
{
    private Camera mainCamera;             //メインカメラ取得
    private float initiatePosY;              //最初のY座標

    bool flashing = true;

    //GameObject obj;

    private int treedowncount = 0;

    public TextSend textsend;

    Animator anim;

    [SerializeField] GameObject HandR;

    Sprite[] ojihands;
    Sprite ojiguSprite;
    Sprite ojipaSprite;

    [SerializeField] GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        initiatePosY = transform.position.y;
        anim = GameObject.Find("TsutumiImage").GetComponent<Animator>();
        ojihands = Resources.LoadAll<Sprite>("Object/hands");
        ojiguSprite = ojihands[1];
        ojipaSprite = ojihands[0];
    }

    // 点滅周期[s]
    [SerializeField] private float _cycle = 0.8f;

    private double _time;

    private void Update()
    {
        //Debug.Log(transform.position.x);

        if (flashing)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;

            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat((float)_time, _cycle);

            // 内部時刻timeにおける明滅状態を反映
            this.gameObject.GetComponent<Image>().enabled = repeatValue >= _cycle * 0.5f;
        }

        /*if (treedowncount >= 3 && textsend.textfinishflag)
        {
            Destroy(this.gameObject, 0.5f);
            textsend.Nextbuttonactive();
        }
        */
    }

    //ドラッグ処理
    private void OnMouseDrag()
    {
        
        if ((this.gameObject.transform.parent.name == "Panel" + GManager.instance.activepanel))
        {
            if(effect)
            {
                Destroy(effect);
            }
            this.gameObject.GetComponent<Image>().sprite = ojiguSprite;
            //マウスのポジションを取得してピースZ座標を代入しておく
            Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x <= -0.5 && -5 <= mousePos.x)
            {
                this.gameObject.GetComponent<Image>().enabled = true;
                flashing = false;
                //mousePos.z = piecePosZ;
                mousePos.y = initiatePosY;
                //ドラッグ中のピースにマウス座標を代入する
                transform.position = mousePos;
            }
            else if (mousePos.x > -0.5)
            {
                Vector2 returnPos;
                returnPos.x = -0.5f;
                returnPos.y = initiatePosY;
                transform.position = returnPos;
            }

            if (transform.position.x <= -4.7)
            {
                Invoke("nextObjsetactive", 0.5f);
                Destroy(this.gameObject, 0.5f);
                anim.SetBool("Tsutumi1flag", true);
            }
        }
    }


    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().sprite = ojipaSprite;
    }

    private void nextObjsetactive()
    {
        HandR.SetActive(true);
    }

}
