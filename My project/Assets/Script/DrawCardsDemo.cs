using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro; // Add this to use TextMeshProUGUI


public class DrawCardsDemo : MonoBehaviour
{
    
    public TextMeshProUGUI deckText;
    public TextMeshProUGUI dropText;
    
    // Start is called before the first frame update
    public GameObject MyArea;
    public GameObject OpponentArea;
    public GameObject Vanguard;
    
    
    // public GameObject WickedBeastSunegosuri;
    // public GameObject StrongStrikeDragonSpinoassaulter;
    // public GameObject StealthRogueOfThrowingSwordKageichi;
    // public GameObject StealthDragonKudenmusubi;
    public GameObject RoaringThunderDragonTriumphDragon;
    // public GameObject RoaringThunderBeastKitenraiz;
    // public GameObject RoaringFlameBeastKaraleor;
    // public GameObject QuaydestDragon;
    // public GameObject JaggyDaggerDragon;
    // public GameObject IronBallDragonAnkybowler;
    // public GameObject HeatedBladeArdart;
    // public GameObject GentleBreezeDragonDinobreeze;
    // public GameObject EscortStealthDragonHayashiKaze;
    // public GameObject ElekirakeDracokid;
    public GameObject ElecblowDragon;
    public GameObject DragritterYumna;
    
    // public GameObject TreuseGreen;
    // public GameObject Eldobreath;
    // public GameObject Barbizonde;
    // public GameObject Connector;
    // public GameObject LouYellow;
    // public GameObject ViolateDragon;
    // public GameObject MeteorShower;
    // public GameObject Peters;
    // public GameObject EclipsedMoonlight;
    // public GameObject Stanner;
    // public GameObject Shergo;
    // public GameObject Hellhazard;
    // public GameObject Rlyk;
    // public GameObject Nordlinger;
    // public GameObject Bacubirito;
    [FormerlySerializedAs("CardList")] public List<GameObject> Deck;
    public List<GameObject> MyHand;
    public List<GameObject> OpponentHand;
    public List<GameObject> DropZone;

    
    
    // void Start()
    // {
    //     // AddMultipleCards(TreuseGreen, 4);
    //     // AddMultipleCards(Eldobreath, 1);
    //     // AddMultipleCards(Barbizonde, 4);
    //     // AddMultipleCards(Connector, 3);
    //     // AddMultipleCards(LouYellow, 4);
    //     // AddMultipleCards(ViolateDragon, 4);
    //     // AddMultipleCards(MeteorShower, 6);
    //     // AddMultipleCards(Peters, 2);
    //     // AddMultipleCards(EclipsedMoonlight, 1);
    //     // AddMultipleCards(Stanner, 3);
    //     // AddMultipleCards(Shergo, 1);
    //     // AddMultipleCards(Hellhazard, 4);
    //     // AddMultipleCards(Rlyk, 2);
    //     // AddMultipleCards(Nordlinger, 3);
    //     // AddMultipleCards(Bacubirito, 4);
    //     
    //     // AddMultipleCards(Bacubirito, 1);
    //     // AddMultipleCards(Nordlinger, 1);
    //     // AddMultipleCards(Rlyk, 1);
    //     // AddMultipleCards(MeteorShower, 1);
    //     AddMultipleCards(Hellhazard, 50);
    //     Shuffle();
    //     
    // }
    
    void Start()
{
    // AddMultipleCards(WickedBeastSunegosuri, 4);
    // AddMultipleCards(StrongStrikeDragonSpinoassaulter, 4);
    // AddMultipleCards(StealthRogueOfThrowingSwordKageichi, 4);
    // AddMultipleCards(StealthDragonKudenmusubi, 4);
    // AddMultipleCards(RoaringThunderDragonTriumphDragon, 4);
    // AddMultipleCards(RoaringThunderBeastKitenraiz, 1);
    // AddMultipleCards(RoaringFlameBeastKaraleor, 1);
    // AddMultipleCards(QuaydestDragon, 4);
    // AddMultipleCards(JaggyDaggerDragon, 4);
    // AddMultipleCards(IronBallDragonAnkybowler, 3);
    // AddMultipleCards(HeatedBladeArdart, 1);
    // AddMultipleCards(GentleBreezeDragonDinobreeze, 4);
    // AddMultipleCards(EscortStealthDragonHayashiKaze, 4);
    // AddMultipleCards(ElekirakeDracokid, 4);
    AddMultipleCards(ElecblowDragon, 4);
    AddMultipleCards(DragritterYumna, 4);
    
    
    AddMultipleCards(RoaringThunderDragonTriumphDragon, 4);

    Shuffle();
}
    public void Shuffle()
    {
        int DeckSize = Deck.Count;
        for (int i = 0; i < DeckSize; i++)
        {
            var randomNumber = Random.Range(0, DeckSize);
            GameObject X = Deck[i];
            Deck[i] = Deck[randomNumber];
            Deck[randomNumber] = X;

        }
    }
    
    void AddMultipleCards(GameObject card, int numberOfCopies)
    {
        for (int i = 0; i < numberOfCopies; i++)
        {
            Deck.Add(Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity));
        }
    }


    
    

    // Update is called once per frame
    void Update()
    {
        // Update the text of the TextMeshProUGUI objects
        deckText.text = "Deck: " + Deck.Count;
        dropText.text = "Drop: " + DropZone.Count;

        // ... rest of your code ...
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
    if (Deck.Count > 0)
    {
        MyHand.Add(Instantiate(Deck[0], new Vector3(0, 0, 0), Quaternion.identity));
        HandDisplay(MyArea, MyHand);
        Destroy(Deck[0]);
        Deck.RemoveAt(0);
        
    }
    else
    {
        Debug.Log("CardList is empty. Cannot perform draw.");
    }
}
public void PerformDraw(int numberOfCards)
{
    for (int i = 0; i < numberOfCards; i++)
    {
        PerformDraw();
    }
}
}
