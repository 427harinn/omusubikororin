using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    [SerializeField] GameObject FirstPanel;
    [SerializeField] GameObject SecondPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked_soundbutton()
    {
        FirstPanel.SetActive(false);
        SecondPanel.SetActive(true);
    }

    public void onClicked_closebutton()
    {
        FirstPanel.SetActive(true);
        SecondPanel.SetActive(false);
    }
}
