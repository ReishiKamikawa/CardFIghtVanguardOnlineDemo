using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPhaseControl : MonoBehaviour
{
    public PhaseController phaseController; // Reference to the PhaseController
    public DrawCardsDemo drawCardsDemo; // Reference to the DrawCardsDemo instance
    private bool hasDrawn; // Flag to check if a card has been drawn in the current draw phase
    private CardHigher cardHigher; // Reference to the CardHigher component

    // Start is called before the first frame update
    void Start()
    {
        hasDrawn = false;
        cardHigher = FindObjectOfType<CardHigher>(); // Get the CardHigher component
    }

    // Update is called once per frame
    void Update()
    {
        if (phaseController.CurrentPhase == GamePhase.DrawPhase)
            
        {
            cardHigher.Reset();
            if (!hasDrawn)
            {
                
                Debug.Log("Draw phase. Attempting to draw a card.");
                drawCardsDemo.PerformDraw();
                hasDrawn = true;
                
                phaseController.NextPhase();
            }
        }
        else
        {
            hasDrawn = false;
        }
    }
}