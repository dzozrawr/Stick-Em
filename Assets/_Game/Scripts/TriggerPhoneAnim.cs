using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPhoneAnim : MonoBehaviour
{
    private bool visibleBool = false, onceBool = false;

    [SerializeField] private GameObject phoneForShowOff;
    [SerializeField] private CameraTransitions cameraTransitions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (visibleBool)
        {
            if (!onceBool)
            {
                if (cameraTransitions.cameraReachedDestination())
                {
                 //   Debug.Log("cameraTransitions.cameraReachedDestination()");
                    phoneForShowOff.SetActive(true);
                    onceBool = true;
                }
            }

        }
    }

    void OnBecameVisible()
    {
        if (!visibleBool)
        {
          // phoneForShowOff.SetActive(true);
           visibleBool = true;
        }
    }
}
