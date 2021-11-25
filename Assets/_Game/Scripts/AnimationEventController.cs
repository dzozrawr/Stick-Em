using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enablePhase2UI()
    {
        gameController.enablePhase2UI();
    }

    public void enablePhase3UI()    //"next" button is removed so it should be actually called goToPhase4()
    {
        // gameController.enablePhase3UI();
        gameController.goToPhase4();
    }

    public void enablePhase4UI()
    {
        gameController.enablePhase4UI();
    }

    public void enablePhase5UI()
    {
        gameController.enablePhase5UI();
    }
}
