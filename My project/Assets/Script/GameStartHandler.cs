using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartHandler : MonoBehaviour
{
    private DrawCardsDemo drawCardsDemo;
    private MulliganControl _mulliganControl;
    [SerializeField]public static bool mulliganComplete = false;
    

    void Start()
{
    
    PhaseController phaseController = FindObjectOfType<PhaseController>();
    phaseController.SetPhase(GamePhase.MulliganPhase);

    Invoke("DelayedStart", 0.1f);
}

    void DelayedStart()
{
    drawCardsDemo = FindObjectOfType<DrawCardsDemo>();
    _mulliganControl = FindObjectOfType<MulliganControl>();

    // Draw initial 5 cards
    for (int i = 0; i < 5; i++)
    {
        drawCardsDemo.PerformDraw();
    }
}

    public void EndMulliganPhase()
    {
        mulliganComplete = true;
        PhaseController phaseController = FindObjectOfType<PhaseController>();
        phaseController.SetPhase(GamePhase.StandPhase);
        phaseController.CompleteFirstMulligan();
    }
    
    public void CallRearGuard()
    {
        if (MainPhaseControl.callCardInMainPhase==true)
        {
            PhaseController phaseController = FindObjectOfType<PhaseController>();
            if (MainPhaseControl.cardSelected && phaseController.SelectedCard != null)
            {
                // Move the selected card to this field
                phaseController.SelectedCard.transform.position = transform.position;
                // Reset the selected card and cardSelected flag
                phaseController.SelectedCard = null;
                MainPhaseControl.cardSelected = false;
            }
            MainPhaseControl.callCardInMainPhase = false;
        }
        
        
    }

}