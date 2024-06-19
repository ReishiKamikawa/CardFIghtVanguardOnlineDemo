using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulliganControl : MonoBehaviour
{
    [SerializeField] private List<CardHigher> hoveredCards;
    public DrawCardsDemo drawCardsDemo;
    private GameStartHandler gameStartHandler; // Add this line


    void Start()
    {
        drawCardsDemo = FindObjectOfType<DrawCardsDemo>();
        gameStartHandler = FindObjectOfType<GameStartHandler>(); // Add this line
    }

    public void OnClick()
    {
        FindHoveredCards();
        RemoveHoveredCardsFromHand();
        drawCardsDemo.Shuffle();
        gameStartHandler.EndMulliganPhase(); // Add this line        
    }

    private void FindHoveredCards()
    {
        hoveredCards = new List<CardHigher>();
        foreach (GameObject cardObject in drawCardsDemo.MyHand)
        {
            CardHigher card = cardObject.GetComponent<CardHigher>();
            if (card != null && card.IsHovered)
            {
                hoveredCards.Add(card);
            }
        }
    }

    private void RemoveHoveredCardsFromHand()
    {
        foreach (CardHigher card in hoveredCards)
        {
            drawCardsDemo.MyHand.Remove(card.gameObject);
            drawCardsDemo.Deck.Add(Instantiate(card.gameObject, new Vector3(0, 0, 0), Quaternion.identity));
            Destroy(card.gameObject);
            drawCardsDemo.PerformDraw();

        }
    }
}