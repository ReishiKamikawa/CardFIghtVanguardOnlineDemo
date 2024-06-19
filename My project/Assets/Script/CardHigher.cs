using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHigher : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField]private float hoverRaiseAmount = 30f; // The amount to raise the card when hovered
    [SerializeField]private bool isHovered=false; // The amount to raise the card when hovered;
    public static CardHigher currentlyHoveredCard = null; // The card that is currently being hovered
    public bool CanHover { get; set; } = true;

    public bool IsHovered
    {
        get => isHovered;
        set => isHovered = value;
    }

    // This method is called when the mouse pointer enters the object
    // public void OnPointerClick(PointerEventData pointerEventData)
    // {
    //     if (!CanHover) return;
    //
    //     // Check if the current card is the Vanguard card
    //     if (this.transform.parent != null && this.transform.parent.name == "Vanguard") return;
    //
    //     if (GameStartHandler.mulliganComplete)
    //     {
    //         if (currentlyHoveredCard != null && currentlyHoveredCard != this)
    //         {
    //             // Un-hover the currently hovered card
    //             currentlyHoveredCard.isHovered = false;
    //             currentlyHoveredCard.transform.position = new Vector3(currentlyHoveredCard.transform.position.x, currentlyHoveredCard.transform.position.y - hoverRaiseAmount, currentlyHoveredCard.transform.position.z);
    //         }
    //
    //         if (isHovered==false)
    //         {
    //             isHovered= true;
    //             transform.position = new Vector3(transform.position.x, transform.position.y + hoverRaiseAmount, transform.position.z);
    //             Debug.Log("Toggle to true: " + isHovered);
    //             currentlyHoveredCard = this;
    //         }
    //         else
    //         {
    //             isHovered = false;
    //             transform.position = new Vector3(transform.position.x, transform.position.y - hoverRaiseAmount, transform.position.z);
    //             currentlyHoveredCard = null;
    //         }
    //     }else
    //     { if (isHovered==false)
    //         {
    //             isHovered= true;
    //             transform.position = new Vector3(transform.position.x, transform.position.y + hoverRaiseAmount, transform.position.z);
    //             Debug.Log("Toggle to true: " + isHovered);
    //         }
    //         else
    //         {
    //             isHovered = false;
    //             transform.position = new Vector3(transform.position.x, transform.position.y - hoverRaiseAmount, transform.position.z);
    //         }
    //     }
    // }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        HoverLogic();
       
    }
    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // Debug.Log("Mouse entered: " + gameObject.name);
    }

    public void HoverLogic()
    {
        if (!CanHover) return;

        if (GameStartHandler.mulliganComplete)
        {
            if (currentlyHoveredCard != null && currentlyHoveredCard != this && currentlyHoveredCard.transform.parent.name == "MyArea")
            {
                // Un-hover the currently hovered card
                currentlyHoveredCard.isHovered = false;
                currentlyHoveredCard.transform.position = new Vector3(currentlyHoveredCard.transform.position.x, currentlyHoveredCard.transform.position.y - hoverRaiseAmount, currentlyHoveredCard.transform.position.z);
            }

            if (isHovered==false)
            {
                isHovered= true;
                transform.position = new Vector3(transform.position.x, transform.position.y + hoverRaiseAmount, transform.position.z);
                currentlyHoveredCard = this;
            }
            else
            {
                isHovered = false;
                transform.position = new Vector3(transform.position.x, transform.position.y - hoverRaiseAmount, transform.position.z);
                currentlyHoveredCard = null;
            }
        }
        else
        {
            if (isHovered==false)
            {
                isHovered= true;
                transform.position = new Vector3(transform.position.x, transform.position.y + hoverRaiseAmount, transform.position.z);
            }
            else
            {
                isHovered = false;
                transform.position = new Vector3(transform.position.x, transform.position.y - hoverRaiseAmount, transform.position.z);
            }
        }
    }
    public void Reset()
    {
        // Find the "MyArea" GameObject
        GameObject myArea = GameObject.Find("MyArea");

        // Check if "MyArea" exists
        if (myArea != null)
        {
            // Iterate over all the children of "MyArea"
            foreach (Transform child in myArea.transform)
            {
                // Get the CardHigher component of the child
                CardHigher card = child.GetComponent<CardHigher>();

                // If the child has a CardHigher component and isHovered is true
                if (card != null && card.IsHovered)
                {
                    // Set isHovered to false
                    card.IsHovered = false;

                    // Lower the card
                    card.transform.position = new Vector3(card.transform.position.x, card.transform.position.y - hoverRaiseAmount, card.transform.position.z);
                }
            }
        }
        else
        {
            Debug.Log("Object named 'MyArea' not found");
        }
    }
}