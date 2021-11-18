using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintOnTouch : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator printingAnimator;
    private bool boolOnce = false;
    
    // Start is called before the first frame update
    void Start()
    {
        printingAnimator.speed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); ;
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                if (objectHit.CompareTag("Printer"))
                {
                    if (!boolOnce)
                    {
                        printingAnimator.speed = 0.5f;
                        boolOnce = true;
                    }
                   
                }
                else
                {
                  //  printingAnimator.speed = 0f;
                }
            }
        }
        else
        {
          //  printingAnimator.speed = 0f;
        }

    }
}
