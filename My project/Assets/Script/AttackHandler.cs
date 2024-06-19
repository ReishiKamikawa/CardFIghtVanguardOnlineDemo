using UnityEngine;
using UnityEngine.EventSystems;

public class AttackHandler : MonoBehaviour, IPointerClickHandler
{
    private BattlePhaseControl battlePhaseControl;

    private void Start()
    {
        battlePhaseControl = GetComponent<BattlePhaseControl>();
        if (battlePhaseControl == null)
        {
            battlePhaseControl = GetComponentInChildren<BattlePhaseControl>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Get all instances of BattlePhaseControl in the scene
        BattlePhaseControl[] allBattlePhaseControls = FindObjectsOfType<BattlePhaseControl>();

        // Iterate over each instance
        foreach (BattlePhaseControl battlePhaseControl in allBattlePhaseControls)
        {
            // Check if IsAttacking is true
            if (battlePhaseControl.IsAttacking)
            {
                Debug.Log(battlePhaseControl.gameObject.name + " is attacking.");
                // This gameObject is attacking
                GameObject attackingObject = battlePhaseControl.gameObject;

                // Check if the parent is EnemyArea
                if (attackingObject.transform.parent != null && attackingObject.transform.parent.name == "EnemyArea")
                {
                    // Log a message
                    Debug.Log("The parent of the attacking object is EnemyArea");
                }
                battlePhaseControl.IsAttacking = false;
            }
        }
    }
}