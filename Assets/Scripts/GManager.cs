using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    public int activepanel = 0;

    public bool gamestopflag = false;

    public float bgmvolume = 0.5f;
    public float sevolume = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}