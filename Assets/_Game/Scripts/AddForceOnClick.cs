using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceOnClick : MonoBehaviour
{
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {                
                hit.rigidbody.AddForceAtPosition(-Vector3.forward*50, hit.point);
            }
        }
    }
}
