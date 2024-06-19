using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StandPhaseController : MonoBehaviour
{
    private PhaseController phaseController;
    private bool called = false;

    void Start()
    {
        phaseController = FindObjectOfType<PhaseController>();
    }

    void Update()
    {
        if (phaseController.CurrentPhase == GamePhase.StandPhase && !called)
        {
            Debug.Log("Stand Phase");

            StandAllCards();
            called = true;
        }
        else if (phaseController.CurrentPhase != GamePhase.StandPhase)
        {
            called = false;
        }
    }

    private void StandAllCards()
    {
        string[] names = { "Vanguard", "Rearguard1", "Rearguard2", "Rearguard3", "Rearguard4", "Rearguard5" };

        foreach (string cardName in names)
        {
            GameObject field = GameObject.Find(cardName);
            if (field != null)
            {
                // Get all BattlePhaseControl components in the children of field
                BattlePhaseControl[] battlePhaseControls = field.GetComponentsInChildren<BattlePhaseControl>();
            
                foreach (BattlePhaseControl battlePhaseControl in battlePhaseControls)
                {
                    Debug.Log("Card found: " + battlePhaseControl.gameObject.name);
                    battlePhaseControl.StandCard();
                }
            }
        }
    }    
    
    
}