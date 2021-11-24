using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingOn : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Animator peelOffAnim;
    [SerializeField] private GameObject finishPoint;
    private bool peelingInitialized = false;
    // Start is called before the first frame update
    void Start()
    {
         peelOffAnim.speed = 0f;    //this line of code is the only difference between this script and PeelingOff script

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!peelingInitialized)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (gameObject == hit.collider.gameObject)
                    {
                        peelingInitialized = true;
                    }
                }
            }

            if (peelingInitialized)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {

                    float animPercentage = (hit.point.z - gameObject.transform.position.z) / (finishPoint.transform.position.z - gameObject.transform.position.z);

                    animPercentage = animPercentage < 0 ? 0 : animPercentage;   //negative values become zero
                    animPercentage = animPercentage > 1 ? 1 : animPercentage;   //values greater than 1 become 1

                    peelOffAnim.Play("PeelOff", 0, animPercentage);     //playing the animation depending on the position of the finger
                                                                            // Debug.Log(animPercentage);
                                                                            //peelingInitialized = true;

                }
            }
        }
        else
        {
            peelingInitialized = false;
        }
    }
}
