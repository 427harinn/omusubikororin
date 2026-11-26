using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseinfoFlashing : MonoBehaviour
{
    [SerializeField] private float _cycle = 0.8f;
    double _time;
    MouseClick_info mouseclick;
    // Start is called before the first frame update
    void Start()
    {
        mouseclick = transform.parent.gameObject.GetComponent<MouseClick_info>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseclick.flashing)
        {
            // “à•”‚ğŒo‰ß‚³‚¹‚é
            _time += Time.deltaTime;

            // üŠúcycle‚ÅŒJ‚è•Ô‚·’l‚Ìæ“¾
            // 0`cycle‚Ì”ÍˆÍ‚Ì’l‚ª“¾‚ç‚ê‚é
            var repeatValue = Mathf.Repeat((float)_time, _cycle);

            // “à•”time‚É‚¨‚¯‚é–¾–Åó‘Ô‚ğ”½‰f
            this.gameObject.GetComponent<Image>().enabled = repeatValue >= _cycle * 0.5f;
        }
    }
}
