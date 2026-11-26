using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMvolumeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetBGMVolume(float volume)
    {
        GManager.instance.bgmvolume = volume;
    }


}
