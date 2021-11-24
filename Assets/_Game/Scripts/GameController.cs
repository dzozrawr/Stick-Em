using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject phase1UI, phase2UI, phase3UI, phase4UI;

    [SerializeField] private GameObject phase1DoneButton, phase2DoneButton, phase3DoneButton, phase4DoneButton;

    [SerializeField] private GameObject paintedSticker, stickerInPrinter, stickerForPeeling, stickerForStickingOn;

    [SerializeField] private CameraTransitions cameraTransitions;

    [SerializeField] private Animator stickerToPeelAnimator;


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
        /*        GameObject go = stickerInPrinter;
                GameObject copyOfThisGo = Instantiate(paintedSticker);

                copyOfThisGo.transform.SetParent(go.transform.parent);

                copyOfThisGo.transform.position = go.transform.position;
                copyOfThisGo.transform.rotation = go.transform.rotation;
                copyOfThisGo.transform.localScale = go.transform.localScale;

                go.GetComponent<Destroyable>().selfDestruct();*/

        phase1UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(2);

        //copy materials from phase1 to all the other stickers in other phases
        Material phase1Material = paintedSticker.transform.GetChild(0).GetComponent<Renderer>().material;       //sticker is the child at index 0, paintedSticker is the EmptyObject parent
                                                                                                                
        Material[] matArray = stickerForPeeling.GetComponent<Renderer>().materials;
        matArray[1] = phase1Material;
        stickerForPeeling.GetComponent<Renderer>().materials = matArray;

        stickerInPrinter.GetComponent<Renderer>().material = phase1Material;

        matArray = stickerForStickingOn.GetComponent<Renderer>().materials;
        matArray[1] = phase1Material;
        stickerForStickingOn.GetComponent<Renderer>().materials = matArray;

        //activate step 1 done
        phase1DoneButton.SetActive(true);
    }

    public void enablePhase2UI()
    {
        phase2UI.SetActive(true);
    }

    public void enablePhase3UI()
    {
        phase3UI.SetActive(true);
    }

    public void enablePhase4UI()
    {
        phase4UI.SetActive(true);
    }

    public void goToPhase3()
    {
        phase2UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(3);

        //activate step 2 done
        phase2DoneButton.SetActive(true);

        //activate fall on ground animation
        stickerToPeelAnimator.SetTrigger("StickerFall");
    }

    public void goToPhase4()
    {
        phase3UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(4);

        //activate step 3 done
        phase3DoneButton.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene("StickEm");
    }
}
