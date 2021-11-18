using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject phase1UI;
    [SerializeField] private GameObject paintedSticker;
    [SerializeField] private GameObject stickerInPrinter;
    [SerializeField] private CameraTransitions cameraTransitions;
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
        GameObject go = stickerInPrinter;
        GameObject copyOfThisGo = Instantiate(paintedSticker);

        copyOfThisGo.transform.SetParent(go.transform.parent);

        copyOfThisGo.transform.position = go.transform.position;
        copyOfThisGo.transform.rotation = go.transform.rotation;
        copyOfThisGo.transform.localScale = go.transform.localScale;

        go.GetComponent<Destroyable>().selfDestruct();

        phase1UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(2);
    }
}
