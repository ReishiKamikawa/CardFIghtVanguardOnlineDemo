using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardsDemo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MyArea;
    public GameObject OpponentArea;
    
    public GameObject TreuseGreen;
    public GameObject Eldobreath;
    public GameObject Barbizonde;
    public GameObject Connector;
    public GameObject LouYellow;
    public GameObject ViolateDragon;
    public GameObject MeteorShower;
    public GameObject Peters;
    public GameObject EclipsedMoonlight;
    public GameObject Stanner;
    public GameObject Shergo;
    public GameObject Hellhazard;
    public GameObject Rlyk;
    public GameObject Nordlinger;
    public GameObject Bacubirito;
    public List<GameObject> CardList;
    public List<GameObject> MyHand;
    public List<GameObject> OpponentHand;

    void Start()
    {
        AddMultipleCards(TreuseGreen, 4);
        AddMultipleCards(Eldobreath, 1);
        AddMultipleCards(Barbizonde, 4);
        AddMultipleCards(Connector, 3);
        AddMultipleCards(LouYellow, 4);
        AddMultipleCards(ViolateDragon, 4);
        AddMultipleCards(MeteorShower, 6);
        AddMultipleCards(Peters, 2);
        AddMultipleCards(EclipsedMoonlight, 1);
        AddMultipleCards(Stanner, 3);
        AddMultipleCards(Shergo, 1);
        AddMultipleCards(Hellhazard, 4);
        AddMultipleCards(Rlyk, 2);
        AddMultipleCards(Nordlinger, 3);
        AddMultipleCards(Bacubirito, 4);
        
        // AddMultipleCards(Bacubirito, 1);
        // AddMultipleCards(Nordlinger, 1);
        // AddMultipleCards(Rlyk, 1);
        // AddMultipleCards(MeteorShower, 1);
        // AddMultipleCards(Hellhazard, 1);
        Shuffle();
        
    }
    
    public void Shuffle()
    {
        int DeckSize = CardList.Count;
        for (int i = 0; i < DeckSize; i++)
        {
            var randomNumber = Random.Range(0, DeckSize);
            GameObject X = CardList[i];
            CardList[i] = CardList[randomNumber];
            CardList[randomNumber] = X;

        }
    }
    
    void AddMultipleCards(GameObject card, int numberOfCopies)
    {
        for (int i = 0; i < numberOfCopies; i++)
        {
            CardList.Add(Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity));
        }
    }


    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandDisplay(GameObject MyArea, List<GameObject> hand)
    {

        foreach (GameObject card in hand)
        {
            card.transform.SetParent(MyArea.transform,false);
            card.GetComponent<CardHigher>().IsHovered = false;
        }
    }

    

    public void OnClick(){
        PerformDraw();
    }

    public void PerformDraw()
    {
        MyHand.Add(Instantiate(CardList[0], new Vector3(0, 0, 0), Quaternion.identity));
        HandDisplay(MyArea, MyHand);
        Destroy(CardList[0]);
        CardList.RemoveAt(0);
        
    }
}
