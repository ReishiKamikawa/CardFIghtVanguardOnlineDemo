using UnityEngine;

public class EndPhaseControl : MonoBehaviour
{
    private PhaseController phaseController;

    private void Start()
    {
        phaseController = FindObjectOfType<PhaseController>();
    }

    public void EndPhase()
    {
        if (phaseController.CurrentPhase == GamePhase.EndPhase)
        {
            phaseController.NextPhase();
        }
    }
}