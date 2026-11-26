using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMvolumeSet : MonoBehaviour
{
    AudioSource bgmaudio;
    // Start is called before the first frame update
    void Start()
    {
        bgmaudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bgmaudio.volume = GManager.instance.bgmvolume;
    }
}
