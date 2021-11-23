using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject phase1UI, phase2UI;

    [SerializeField] private GameObject phase1DoneButton, phase2DoneButton, phase3DoneButton, phase4DoneButton;

    [SerializeField] private GameObject paintedSticker, stickerInPrinter,stickerForPeeling;    

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

        //copy materials from phase1 to stickerForPeeling
        Material phase1Material=  paintedSticker.transform.GetChild(0).GetComponent<Renderer>().material;       //sticker is the child at index 0, paintedSticker is the EmptyObject parent
        stickerForPeeling.GetComponent<Renderer>().material = phase1Material;

        //activate step 1 done
        phase1DoneButton.SetActive(true);
    }

    public void enablePhase2UI()
    {
        phase2UI.SetActive(true);
    }

    public void goToPhase3()
    {
        phase2UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(3);

        //activate step 1 done
        phase2DoneButton.SetActive(true);
    }


}
