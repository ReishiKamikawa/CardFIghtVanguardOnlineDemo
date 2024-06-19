using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required for IPointerClickHandler
using System.Linq; // Required for Contains method
using UnityEngine.UI; // Required for Button
public class BattlePhaseControl : MonoBehaviour, IPointerClickHandler
{
    public bool IsAttacking = false; // Flag to check if the card is attacking

    public PhaseController phaseController;
    public bool stand = true; // Add this line
    public bool rest = false; // Add this line
    public GameObject attackButtonPrefab; // Prefab for the attack button
    private GameObject attackButton; // Reference to the instantiated attack button
    void Start()
    {
        phaseController = FindObjectOfType<PhaseController>();
    }

    public void OnClick()
    {
        if (phaseController.CurrentPhase == GamePhase.BattlePhase)
        {
            // Implement the logic for the battle phase here
            // After the logic is done, move to the next phase
            phaseController.NextPhase();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (phaseController.CurrentPhase == GamePhase.BattlePhase)
        {
            CardDisplay cardDisplay = GetComponent<CardDisplay>();
            if (cardDisplay == null)
            {
                cardDisplay = GetComponentInChildren<CardDisplay>();
            }
            if (cardDisplay != null)
            {
                string[] validNames = { "Vanguard", "Rearguard1", "Rearguard2", "Rearguard3", "Rearguard4", "Rearguard5" };
                if (validNames.Contains(gameObject.name) || (transform.parent != null && validNames.Contains(transform.parent.name)))
                {
                    if (stand)
                    {
                        if (attackButton == null)
                        {
                            // Instantiate the attack button as a child of the card
                            attackButton = Instantiate(attackButtonPrefab, transform);
                            // Set the local position of the button
                            attackButton.transform.localPosition = new Vector3(150, 0, 0);
                            // Add an OnClick event to the button that calls the OnAttack method
                            attackButton.GetComponent<Button>().onClick.AddListener(OnAttack);
                        }
                        else
                        {
                            // Toggle the active state of the button
                            attackButton.SetActive(!attackButton.activeSelf);
                        }
                    }
                }
            }
        }
        
        
        
    }
    
    
    public void StandCard()
    {
        Debug.Log("StandCard method called"); // Debug statement

        // Check if the card is not already standing
        if (!stand)
        {
            // Get the CardDisplay component of the card
            CardDisplay cardDisplay = GetComponent<CardDisplay>();
            if (cardDisplay == null)
            {
                // If the current object doesn't have a CardDisplay, check if any child object has a CardDisplay
                cardDisplay = GetComponentInChildren<CardDisplay>();
            }
            if (cardDisplay != null)
            {
                // Get the Image component of the card from a child GameObject
                Image cardImage = cardDisplay.gameObject.GetComponentInChildren<Image>();
                if (cardImage != null)
                {
                    // Rotate the image of the card to stand it
                    cardImage.rectTransform.Rotate(0, 0, 90);
                }
                stand = true;
                rest = false;
            }
        }
    }

    public void RestCard()
    {
        // Check if the card is not already resting
        if (!rest)
        {
            // Get the CardDisplay component of the card
            CardDisplay cardDisplay = GetComponent<CardDisplay>();
            if (cardDisplay == null)
            {
                // If the current object doesn't have a CardDisplay, check if any child object has a CardDisplay
                cardDisplay = GetComponentInChildren<CardDisplay>();
            }
            if (cardDisplay != null)
            {
                // Get the Image component of the card from a child GameObject
                Image cardImage = cardDisplay.gameObject.GetComponentInChildren<Image>();
                if (cardImage != null)
                {
                    // Rotate the image of the card to rest it
                    cardImage.rectTransform.Rotate(0, 0, -90);
                }
                stand = false;
                rest = true;
            }
        }
    }
    
    // public void OnPointerClick(PointerEventData eventData)
    // {
    //     if (phaseController.CurrentPhase == GamePhase.BattlePhase)
    //     {
    //         CardDisplay cardDisplay = GetComponent<CardDisplay>();
    //         if (cardDisplay == null) // If the current object doesn't have a CardDisplay
    //         {
    //             cardDisplay = GetComponentInChildren<CardDisplay>(); // Check if any child object has a CardDisplay
    //         }
    //         if (cardDisplay != null) // If a CardDisplay was found
    //         {
    //             string[] validNames = { "Vanguard", "Rearguard1", "Rearguard2", "Rearguard3", "Rearguard4", "Rearguard5" };
    //             if (validNames.Contains(gameObject.name) || (transform.parent != null && validNames.Contains(transform.parent.name)))
    //             {
    //                 Debug.Log("Card identified: " + gameObject.name); // Log the name of the card
    //
    //                 if (rest) // If the card is resting
    //                 {
    //                     Debug.Log("Card is resting. Returning to normal state."); // Log the current state
    //                     transform.Rotate(0, 0, 90); // Rotate the object -90 degrees to return it to its normal state
    //                     stand = true;
    //                     rest = false;
    //                 }
    //                 else if (stand) // If the card is standing
    //                 {
    //                     Debug.Log("Card is standing. Resting card."); // Log the current state
    //                     transform.Rotate(0, 0, -90); // Rotate the object 90 degrees to rest it
    //                     stand = false;
    //                     rest = true;
    //                     
    //                 }
    //             }
    //         }
    //     }
    // }    
    
    private void OnAttack()
    {
        // Implement the logic for the attack here
        if (stand)
        {
            IsAttacking = true;

            // // Get the CardDisplay component of the card
            // CardDisplay cardDisplay = GetComponent<CardDisplay>();
            // if (cardDisplay == null)
            // {
            //     // If the current object doesn't have a CardDisplay, check if any child object has a CardDisplay
            //     cardDisplay = GetComponentInChildren<CardDisplay>();
            // }
            // if (cardDisplay != null)
            // {
            //     // Get the Image component of the card from a child GameObject
            //     Image cardImage = cardDisplay.gameObject.GetComponentInChildren<Image>();
            //     if (cardImage != null)
            //     {
            //         // Rotate the image of the card
            //         cardImage.rectTransform.Rotate(0, 0, -90);
            //     }
            //     stand = false;
            //     rest = true;
            // }
            RestCard();
        }
        attackButton.SetActive(false);

    }
    

}