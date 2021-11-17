using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceSticker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject go=GameObject.FindGameObjectWithTag("StickerInPrinter");
            gameObject.transform.position= go.transform.position;
        }
    }
}
