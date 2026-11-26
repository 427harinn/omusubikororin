using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    [SerializeField] GameObject YazirusiImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Objdestroy()
    {
        Destroy(this.gameObject);
        if(YazirusiImage)
        {
            Destroy(YazirusiImage);
        }
        
    }
}
