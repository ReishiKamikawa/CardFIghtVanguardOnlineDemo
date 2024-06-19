using System;
using UnityEngine;
using TMPro;

public enum GamePhase
{
    MulliganPhase,
    StandPhase,
    DrawPhase,
    RidePhase,
    MainPhase,
    BattlePhase,
    EndPhase
}
public class PhaseController : MonoBehaviour
{
    public GamePhase CurrentPhase { get; private set; }
    public TextMeshProUGUI phaseText; // Make this public
    [SerializeField]private bool isFirstMulliganComplete = false;
    public CardHigher SelectedCard { get; set; }
    [SerializeField] private CardHigher cardHigher; // Add this line

    private void Start()
    {
        CurrentPhase = GamePhase.MulliganPhase; // Start with MulliganPhase
        UpdatePhaseText();
        
    }

    public void NextPhase()
    {
        cardHigher.Reset(); // Add this line

        if (CurrentPhase == GamePhase.EndPhase)
        {
            // After the first MulliganPhase, the next phase after EndPhase will be StandPhase
            CurrentPhase = isFirstMulliganComplete ? GamePhase.StandPhase : GamePhase.MulliganPhase;
        }
        else
        {
            CurrentPhase = (GamePhase)(((int)CurrentPhase + 1) % System.Enum.GetNames(typeof(GamePhase)).Length);
        }
        UpdatePhaseText();

    }
    
    public void OnClick()
    {
        NextPhase();
    }

    public void SetPhase(GamePhase phase)
    {
        CurrentPhase = phase;
        UpdatePhaseText();
    }

    public void CompleteFirstMulligan()
    {
        isFirstMulliganComplete = true;
    }

    private void UpdatePhaseText()
    {
        phaseText.text = Enum.GetName(typeof(GamePhase), CurrentPhase);
    }
}