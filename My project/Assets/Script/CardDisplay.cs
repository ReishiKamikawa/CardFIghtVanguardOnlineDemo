using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace

public class CardDisplay : MonoBehaviour
{
    public Cards cards;
    public string CardName;
    public int grade;
    public string skill;
    public Image Art;
    public string BushiId;
    public bool rideDeck;
    public int numberInDeck;
    public int power;
    public int shield;
    public int critical;

    public TextMeshProUGUI powerText; // Reference to the TextMeshPro component
    public TextMeshProUGUI criticalText; // New TextMeshPro component for critical
    public TextMeshProUGUI gradeText; // New TextMeshPro component for shield
    void Start()
    {
        Art.sprite = cards.Art;
        powerText.text = cards.power.ToString(); // Update the text to display the power of the card
        criticalText.text = cards.critical.ToString(); // Update the text to display the critical of the card
        gradeText.text = cards.grade.ToString(); // Update the text to display the grade of the card
    }

    // Update is called once per frame
    void Update()
    {

    }
}