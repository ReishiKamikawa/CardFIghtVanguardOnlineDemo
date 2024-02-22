using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Cards cards;
    public string CardName;
    public int grade;
    public string skill;
    public Image Art;
    public string BushiId;
    public bool rideDeck;
    public int numberInDeck;

   

    void Start()
    {
        Art.sprite = cards.Art;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
