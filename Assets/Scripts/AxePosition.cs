using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxePosition : MonoBehaviour
{
    private Vector3 _initialPosition; // 初期位置
    private Camera mainCamera;             //メインカメラ取得
    private float piecePosZ;               //ピースのZ座標

    bool flashing = true;

    //GameObject obj;

    private int treedowncount = 0;

    public TextSend textsend;
    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = gameObject.transform.position;
        mainCamera = Camera.main;
        piecePosZ = transform.position.z;
    }

    // 点滅周期[s]
    [SerializeField] private float _cycle = 0.8f;

    private double _time;

    private void Update()
    {
        if(flashing)
        {
            // 内部時刻を経過させる
            _time += Time.deltaTime;

            // 周期cycleで繰り返す値の取得
            // 0～cycleの範囲の値が得られる
            var repeatValue = Mathf.Repeat((float)_time, _cycle);

            // 内部時刻timeにおける明滅状態を反映
            this.gameObject.GetComponent<Image>().enabled = repeatValue >= _cycle * 0.5f;
        }

        if(treedowncount >= 3)
        {
            Destroy(this.gameObject,0.5f);
            textsend.gimmick = false;
        }

    }

    //ドラッグ処理
    private void OnMouseDrag()
    {
        this.gameObject.GetComponent<Image>().enabled = true;
        flashing = false;
        //マウスのポジションを取得してピースZ座標を代入しておく
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = piecePosZ;

        //ドラッグ中のピースにマウス座標を代入する
        transform.position = mousePos;
    }

    private void OnMouseExit()
    {
        gameObject.transform.position = _initialPosition; // 位置の初期化
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "tree")
        {
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            treedowncount++;
            Animator anim = GameObject.Find(collision.gameObject.name).transform.GetChild(1).GetComponent<Animator>();

            TreedownAnim(anim);
        }

    }

    private void TreedownAnim(Animator anim)
    {
        anim.SetTrigger("cuttrigger");   
    }


}