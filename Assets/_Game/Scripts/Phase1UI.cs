using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phase1UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToPhase2()
    {
        GameObject go = GameObject.FindGameObjectWithTag("StickerInPrinter");
        GameObject copyOfThisGo = Instantiate(gameObject);

        copyOfThisGo.transform.SetParent(go.transform.parent);

        copyOfThisGo.transform.position = go.transform.position;
        copyOfThisGo.transform.rotation = go.transform.rotation;
        copyOfThisGo.transform.localScale = go.transform.localScale;

        go.GetComponent<Destroyable>().selfDestruct();
    }
}
