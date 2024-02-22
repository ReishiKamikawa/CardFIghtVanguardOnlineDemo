using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Card",menuName = "Cards/TestCard")]
public class Cards : ScriptableObject
{
    public string CardName;
    public int grade;
    public string skill;
    public Sprite Art;
    public string BushiId;
    public bool rideDeck;
    public int numberInDeck;
}
