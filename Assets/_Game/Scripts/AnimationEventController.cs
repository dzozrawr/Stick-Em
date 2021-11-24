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

    public void enablePhase3UI()
    {
        gameController.enablePhase3UI();
    }

    public void enablePhase4UI()
    {
        gameController.enablePhase4UI();
    }
}
