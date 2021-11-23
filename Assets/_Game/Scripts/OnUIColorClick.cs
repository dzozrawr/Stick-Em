using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using PaintIn3D.Examples;

public class OnUIColorClick : MonoBehaviour
{

    [SerializeField] private Sprite notActiveImg, activeImg;
    private Transform target;
    [SerializeField] private P3dButtonIsolate buttonScript;

    // Start is called before the first frame update
    void Start()
    {       
        if (buttonScript!=null)
        {
            target=buttonScript.Target;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
            if (target.gameObject.activeInHierarchy == true)
            {
                GetComponent<Image>().sprite = activeImg;
                
            }
            else
            {
                GetComponent<Image>().sprite = notActiveImg;
            }
            // group.alpha = target.gameObject.activeInHierarchy == true ? 1.0f : 0.5f;

        }
        else
        {
            Debug.Log("GetComponent<Image>().sprite = activeImg;");
        }
    }

}
