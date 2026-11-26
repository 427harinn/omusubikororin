using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandR : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera mainCamera;             //メインカメラ取得
    private float initiatePosY;              //最初のY座標

    bool flashing = true;

    //GameObject obj;

    private int treedowncount = 0;

    public TextSend textsend;

    Animator anim;

    Sprite[] ojihands;
    Sprite ojiguSprite;
    Sprite ojipaSprite;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        initiatePosY = transform.position.y;
        anim = GameObject.Find("TsutumiImage").GetComponent<Animator>();

        ojihands = Resources.LoadAll<Sprite>("Object/hands");
        ojiguSprite = ojihands[3];
        ojipaSprite = ojihands[2];
    }

    // 点滅周期[s]
    [SerializeField] private float _cycle = 0.8f;

    private double _time;

    private void Update()
    {
        Debug.Log(transform.position.x);

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
        this.gameObject.GetComponent<Image>().sprite = ojiguSprite;
        //マウスのポジションを取得してピースZ座標を代入しておく
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x >= 1.15f && 5.5f >= mousePos.x)
        {
            this.gameObject.GetComponent<Image>().enabled = true;
            flashing = false;
            //mousePos.z = piecePosZ;
            mousePos.y = initiatePosY;
            //ドラッグ中のピースにマウス座標を代入する
            transform.position = mousePos;
        }
        else if (mousePos.x < 1.15f)
        {
            Vector2 returnPos;
            returnPos.x = 1.15f;
            returnPos.y = initiatePosY;
            transform.position = returnPos;
        }

        if (transform.position.x >= 5.0f)
        {
            Destroy(this.gameObject, 0.5f);
            anim.SetBool("Tsutumi2flag", true);
            textsend.gimmick = false;
        }

    }

    private void OnMouseExit()
    {
        this.gameObject.GetComponent<Image>().sprite = ojipaSprite;
    }

}
