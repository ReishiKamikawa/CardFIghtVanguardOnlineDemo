using UnityEngine;
using UnityEngine.EventSystems;

public class CardCallToRear : MonoBehaviour, IPointerClickHandler
{
    private PhaseController phaseController;
    private CardMovement cardMovement;
    private DrawCardsDemo drawCardsDemo;

    private void Start()
    {
        phaseController = FindObjectOfType<PhaseController>();
        cardMovement = FindObjectOfType<CardMovement>();
        drawCardsDemo = FindObjectOfType<DrawCardsDemo>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (MainPhaseControl.callCardInMainPhase == true && eventData.pointerPress.transform.parent.name != "Vanguard")
        {
            CallRearGuard();
            MainPhaseControl.callCardInMainPhase = false;
        }
    }

    public void CallRearGuard()
    {
        if (MainPhaseControl.cardSelected && phaseController.SelectedCard != null
                                          && transform.parent.name != "Vanguard"
                                          && transform.parent.name != "MyArea")
        {
            // Change targetObjectName to the parent object's name
            string targetObjectName = this.transform.parent.name;

            // Log the name of the parent object
            Debug.Log("Parent object name: " + targetObjectName);

            
                GameObject dropZone = GameObject.Find("Drop");

                GameObject oldCard = transform.gameObject;
                oldCard.transform.SetParent(dropZone.transform);
                oldCard.SetActive(false);

                drawCardsDemo.DropZone.Add(oldCard);
            

            cardMovement.MoveToObject(targetObjectName);

            CardHigher cardHigher = phaseController.SelectedCard.GetComponent<CardHigher>();
            if (cardHigher != null)
            {
                cardHigher.IsHovered = false;
            }

            phaseController.SelectedCard = null;
            MainPhaseControl.cardSelected = false;
        }
    }
    
}