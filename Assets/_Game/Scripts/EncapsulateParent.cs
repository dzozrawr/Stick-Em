using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncapsulateParent : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        Bounds bounds = parent.GetComponent<Renderer>().bounds;

        gameObject.GetComponent<MeshFilter>().mesh.bounds.Encapsulate(bounds);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
