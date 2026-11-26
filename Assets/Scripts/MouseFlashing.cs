using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFlashing : MonoBehaviour
{
    [SerializeField] private float _cycle = 0.8f;

    private double[] _time = new double[3];
    [SerializeField] MouseClick mouseclickscript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mouseclickscript.flashing.Length; i++)
        {
            if (mouseclickscript.flashing[i])
            {
                // “à•”Žž‚ðŒo‰ß‚³‚¹‚é
                _time[i] += Time.deltaTime;

                // ŽüŠúcycle‚ÅŒJ‚è•Ô‚·’l‚ÌŽæ“¾
                // 0`cycle‚Ì”ÍˆÍ‚Ì’l‚ª“¾‚ç‚ê‚é
                var repeatValue = Mathf.Repeat((float)_time[i], _cycle);

                // “à•”Žžtime‚É‚¨‚¯‚é–¾–Åó‘Ô‚ð”½‰f
                mouseclickscript.mousebutton[i].transform.GetChild(0).GetComponent<Image>().enabled = repeatValue >= _cycle * 0.5f;
            }
        }
    }
}
