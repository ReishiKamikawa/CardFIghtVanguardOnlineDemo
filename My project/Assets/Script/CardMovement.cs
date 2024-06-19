using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovement : MonoBehaviour
{
    public GameObject targetObject; // The target object to move the card to
    
    public void OnClick()
    {
        // Get the DrawCardsDemo instance
        DrawCardsDemo drawCardsDemo = FindObjectOfType<DrawCardsDemo>();

        // Get all hovered cards
        List<CardHigher> hoveredCards = GetAllHoveredCards(drawCardsDemo.MyHand);
        GameObject vanguardObject = GameObject.Find("Rearguard1");

        if (vanguardObject != null)
        {
            targetObject = vanguardObject;
            // Change the object's position
            foreach (CardHigher card in hoveredCards)
            {
                card.IsHovered = false;
                card.transform.position = targetObject.transform.position;
                drawCardsDemo.MyHand.Remove(card.gameObject);
                card.transform.SetParent(targetObject.transform);
                card.CanHover = false;
            }        
        }
        else
        {
            Debug.Log("Object named 'Vanguard' not found");
        }

    }

    public void MoveToObject(string objectName)
    {
        // Get the DrawCardsDemo instance
        DrawCardsDemo drawCardsDemo = FindObjectOfType<DrawCardsDemo>();

        // Get all hovered cards
        List<CardHigher> hoveredCards = GetAllHoveredCards(drawCardsDemo.MyHand);
        GameObject vanguardObject = GameObject.Find(objectName); // Use the parameter objectName

        if (vanguardObject != null)
        {
            targetObject = vanguardObject;
            // Change the object's position
            foreach (CardHigher card in hoveredCards)
            {
                card.IsHovered = false;
                card.transform.position = targetObject.transform.position;
                drawCardsDemo.MyHand.Remove(card.gameObject);
                card.transform.SetParent(targetObject.transform);
                card.CanHover = false;
            }
        }
        else
        {
            Debug.Log("Object named '" + objectName + "' not found"); // Use the parameter objectName in the log message
        }
    }
    public List<CardHigher> GetAllHoveredCards(List<GameObject> hand)
    {
        List<CardHigher> hoveredCards = new List<CardHigher>();

        foreach (GameObject cardObject in hand)
        {
            CardHigher card = cardObject.GetComponent<CardHigher>();
            if (card != null && card.IsHovered)
            {
                hoveredCards.Add(card);
            }
        }
        return hoveredCards;
    }
}