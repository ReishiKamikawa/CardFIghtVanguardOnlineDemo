using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidePhaseControl : MonoBehaviour
{
    public PhaseController phaseController;
    public CardMovement cardMovement; // Reference to the CardMovement instance
    public List<GameObject> soul = new List<GameObject>(); // New list to hold the cards moved from Vanguard
    private CardHigher cardHigher; // Reference to the CardHigher component

    void Start()
    {
        phaseController = FindObjectOfType<PhaseController>();
        cardMovement = FindObjectOfType<CardMovement>();
        cardHigher = cardMovement.GetComponent<CardHigher>(); // Get the CardHigher component
    }

    public void OnClick()
    {
        if (phaseController.CurrentPhase == GamePhase.RidePhase)
        {
            GameObject vanguardObject = GameObject.Find("Vanguard");
            if (vanguardObject.transform.childCount > 1) // Check if there is already a card at Vanguard
            {
                GameObject oldCard = vanguardObject.transform.GetChild(1).gameObject; // Get the existing card
                soul.Add(oldCard); // Add the existing card to the soul
                oldCard.SetActive(false); // Remove the existing card from the UI
                oldCard.transform.SetParent(null); // Remove the existing card from the parent
            }
            if (cardHigher != null)
            {
                cardHigher.IsHovered = false; // Set IsHovered to false
                cardHigher.CanHover = false; // Set CanHover to false
            }
            cardMovement.MoveToObject("Vanguard"); // Move the new card to Vanguard
         
            phaseController.NextPhase(); // Move to the next phase
        }
    }
}