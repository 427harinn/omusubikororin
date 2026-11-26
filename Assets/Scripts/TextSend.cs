using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSend : MonoBehaviour
{
    [SerializeField] GameObject nextButton;
    [Header("テキスト後ギミックが有るかどうか")]
    public bool gimmick;
    [Header("パネルの再生が始まった瞬間trueにするオブジェ")]
    public GameObject effect;

    private string talks;
    public Text textLabel;

    bool textstart = false;

    public bool audiopauseflag = false;
    //public AudioClip sound;

    int messageCount = 0;

    public bool textfinishflag;

    AudioSource audio;
    private void Start()
    {
        talks = textLabel.text;
        textLabel.text = "";
    }
    private void Update()
    {
        if (this.gameObject.name == "Panel" + GManager.instance.activepanel && !textstart)
        {
            audio = this.gameObject.GetComponent<AudioSource>();
            audio.enabled = true;
            audio.volume = GManager.instance.sevolume;
            GameObject[]children = new GameObject[this.gameObject.transform.childCount];
            if (effect)
            {
                effect.SetActive(true);
            }
            // 0～個数-1までの子を順番に配列に格納
            for (int i = 0; i < children.Length; ++i)
            {
                children[i] = this.gameObject.transform.GetChild(i).gameObject;
                var component = children[i].gameObject.GetComponent<Animator>();
                if (component != null)
                {
                    component.SetTrigger("animtrigger");
                }
            }

            /*
            if (this.gameObject.transform.Find("OjiImage"))
            {
                this.gameObject.transform.Find("OjiImage").GetComponent<Animator>().SetTrigger("animtrigger");
            }
            */

            textstart = true;
            StartCoroutine(Dialogue());
        }

        //音再生中に設定画面が開かれたら音を止める
        if(GManager.instance.gamestopflag && audioplaying())
        {
            if(effect)
            {
                effect.SetActive(false);
            }
            
            if (audio)
            {
                audiopauseflag = true;
                audio.Pause();
            }
            
        }

        if (!GManager.instance.gamestopflag && !audioplaying() && audiopauseflag)
        {
            if(effect)
            {
                effect.SetActive(true);
            }
            
            if (audio)
            {
                audiopauseflag = false;
                audio.Play();
                audio.volume = GManager.instance.sevolume;
            }
        }

        
    }

    private void FixedUpdate()
    {
        if(!audioplaying())
        {
            textfinishflag = true;
        }

        if (!gimmick && textfinishflag && GManager.instance.activepanel != 22)
        {
            Nextbuttonactive();
        }
        
    }

    bool audioplaying()
    {
        if(audio)
        {
            return audio.isPlaying;
        } else
        {
            return true;
        }
        
    }

    // コルーチンを使って、１文字ごと表示する。
    IEnumerator Dialogue()
    {
        while (talks.Length > messageCount)
        {
            textfinishflag = false;
            textLabel.text += talks[messageCount];
            messageCount++;
            yield return new WaitForSeconds(0.2f);
        }
        
        /*
        if(!gimmick)
        {
            Nextbuttonactive();
        }*/

    }

    public void Nextbuttonactive()
    {
        nextButton.SetActive(true);
        textstart = false;
    }

}