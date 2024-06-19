using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FieldOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image image;
    public PhaseController phaseController; // Reference to the PhaseController
    public DrawCardsDemo drawCardsDemo; // Reference to the DrawCardsDemo script

    private void Start()
    {
        image = GetComponent<Image>();
        drawCardsDemo = GameObject.FindObjectOfType<DrawCardsDemo>(); // Find the DrawCardsDemo script
        phaseController = GameObject.FindObjectOfType<PhaseController>(); // Find the PhaseController script
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
            // if (eventData != null && eventData.pointerPress != null && eventData.pointerPress.name != "Vanguard")
            // {
            //     if (image != null)
            //     {
            //         image.color = new Color(1, 0.5f, 0); // RGB for Orange
            //     }
            // }
            if (image != null)
            {
                image.color = new Color(1, 0.5f, 0); // RGB for Orange
            }
            
        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null)
        {
            image.color = Color.white; // Change back to white when pointer exits
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainPhaseControl.callCardInMainPhase==true && eventData.pointerPress.name != "Vanguard")
        {
            CallRearGuard();
            MainPhaseControl.callCardInMainPhase = false;
        }
    }
    public void CallRearGuard()
    {
        PhaseController phaseController = FindObjectOfType<PhaseController>();
        CardMovement cardMovement = FindObjectOfType<CardMovement>(); // Get the CardMovement instance
        DrawCardsDemo drawCardsDemo = FindObjectOfType<DrawCardsDemo>(); // Get the DrawCardsDemo instance

        if (MainPhaseControl.cardSelected && phaseController.SelectedCard != null)
        {
            // Get the name of the current game object
            string targetObjectName = this.gameObject.name;

            // Check if the current game object has any child objects
            if (transform.childCount > 1)
            {
                GameObject dropZone = GameObject.Find("Drop");

                // Move the old card to the DropZone
                GameObject oldCard = transform.GetChild(1).gameObject;
                oldCard.transform.SetParent(dropZone.transform);
                oldCard.SetActive(false);
                // Add the old card to the DropZone list in the DrawCardsDemo class
                drawCardsDemo.DropZone.Add(oldCard);
            }

            // Move the selected card to this field
            cardMovement.MoveToObject(targetObjectName);

            // Get the CardHigher component of the selected card and set IsHovered to false
            CardHigher cardHigher = phaseController.SelectedCard.GetComponent<CardHigher>();
            if (cardHigher != null)
            {
                cardHigher.IsHovered = false;
            }

            // Reset the selected card and cardSelected flag
            phaseController.SelectedCard = null;
            MainPhaseControl.cardSelected = false;
        }
    }}