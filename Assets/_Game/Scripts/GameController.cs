using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject phase1UI, phase2UI, phase3UI, phase4UI, phase5UI;

    [SerializeField] private GameObject phase1DoneButton, phase2DoneButton, phase3DoneButton, phase4DoneButton;

    [SerializeField] private GameObject paintedSticker, stickerInPrinter, stickerForPeeling, stickerForStickingOn, phoneCase, phoneCaseForShowing, stickerForRipping1=null, stickerForRipping2 = null;  

    [SerializeField] private CameraTransitions cameraTransitions;

    [SerializeField] private Animator stickerToPeelAnimator;
    [SerializeField] private RuntimeAnimatorController stickingOnAnimator;

    private bool isGoToPhase4Active = false;
    private Vector3 phoneCaseDestination;
    [SerializeField] private float phoneCaseTransitionSpeed;

    [SerializeField] private GameObject triggerForPhoneShowing, backgroundCanvas=null;

    //[SerializeField] private Transform stickerForPeeling, phase2UI, phase3UI, phase4UI;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGoToPhase4Active)
        {
            phoneCase.transform.position = Vector3.Lerp(phoneCase.transform.position, phoneCaseDestination , Time.deltaTime * phoneCaseTransitionSpeed);
        }
        //if goToPhase4 is activated
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

        if (backgroundCanvas != null)
        {
            backgroundCanvas.SetActive(false);
        }

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

        phoneCaseForShowing.GetComponent<Renderer>().material = phase1Material;

        //ripping part

        if (stickerForRipping1 != null)
        {
            stickerForRipping1.GetComponent<Renderer>().material = phase1Material;
        }

        if (stickerForRipping2 != null)
        {
            matArray = stickerForRipping2.GetComponent<Renderer>().materials;
            matArray[1] = phase1Material;
            stickerForRipping2.GetComponent<Renderer>().materials = matArray;
        }


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

    public void enablePhase5UI()
    {
        phase5UI.SetActive(true);
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
        /*        phase3UI.SetActive(false);
                cameraTransitions.transitionCameraToPhase(4);

                //activate step 3 done
                phase3DoneButton.SetActive(true);*/

        //disable-uj stare hitboxevime
        //novi sticker zameni stari sticker (u kom trenutku?)
        //phone case se lerpuje zajedno sa novim hitboxevima samo do zeljene x koordinate
        //transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        phase3UI.SetActive(false);

        //activate step 3 done
        phase3DoneButton.SetActive(true);

        phoneCaseDestination =new Vector3(stickerForPeeling.transform.position.x, phoneCase.transform.position.y, phoneCase.transform.position.z);
        Transform parentPeeling= stickerForPeeling.transform.parent, parentSticking= stickerForStickingOn.transform.parent;
        
       // parentPeeling.GetComponent<Animator>().runtimeAnimatorController = parentSticking.GetComponent<Animator>().runtimeAnimatorController;
       
        parentPeeling.GetComponent<Animator>().runtimeAnimatorController = stickingOnAnimator;
       // parentPeeling.GetComponent<Animator>().Play("PeelOffFixed", 0, 0);
        parentPeeling.GetComponent<Animator>().speed = 0;
        isGoToPhase4Active = true;
    }

    public void goToPhase5()
    {
        triggerForPhoneShowing.SetActive(true); //trigger is set visible only here, because in phase 1 it is visible
        phase4UI.SetActive(false);
        cameraTransitions.transitionCameraToPhase(5);

        //  SceneManager.LoadScene("StickEm");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("StickEm");
    }


}
