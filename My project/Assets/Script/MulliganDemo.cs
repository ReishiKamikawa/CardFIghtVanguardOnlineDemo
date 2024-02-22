using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulliganDemo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private List<CardHigher> hoveredCards ;
    public DrawCardsDemo drawCardsDemo; // Reference to DrawCardsDemo

    public 
    void Start()
    {
        drawCardsDemo = FindObjectOfType<DrawCardsDemo>(); // Find the DrawCardsDemo object in the scene

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        // Find all game objects with the tag "isHovered"
        this.hoveredCards = new List<CardHigher>();
        FindhoveredCards();
        Debug.Log("Hovered cards: " + hoveredCards.Count);
        // Do something with hoveredCards
        foreach (CardHigher card in hoveredCards)
        {
            //Remove the hovered card from the hand
            drawCardsDemo.MyHand.Remove(card.gameObject);
            drawCardsDemo.CardList.Add(Instantiate(card.gameObject, new Vector3(0, 0, 0), Quaternion.identity));
            // Remove the card from the myArea
            Destroy(card.gameObject);
            drawCardsDemo.PerformDraw();
        }
        drawCardsDemo.Shuffle();
    }
    
    private void  FindhoveredCards()
    {
        // hoveredCards.Clear();
        Debug.Log("MyHand count: " + drawCardsDemo.MyHand.Count);
        
        foreach (GameObject cardObject in drawCardsDemo.MyHand)
        {
            CardHigher card = cardObject.GetComponent<CardHigher>();// Maybe this is the problem
            Debug.Log("Card Hovered: " + card.IsHovered);
            if (card != null && card.IsHovered==true)
            {
                hoveredCards.Add(card);
            }
        }
    }
}
