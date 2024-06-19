// using UnityEngine;
// using UnityEngine.UI;
//
// public class MainPhaseButton : MonoBehaviour
// {
//     [SerializeField] private Button buttonPrefab; // Reference to the button prefab
//     private Button hoverButton; // Reference to the instantiated button
//     private CardHigher cardHigher; // Reference to the CardHigher component
//     private PhaseController phaseController; // Reference to the PhaseController component
//     public static bool cardSelected = false;
//     public static bool callCardInMainPhase = false;
//     void Start()
//     {
//         // Get the CardHigher and PhaseController components
//         cardHigher = GetComponent<CardHigher>();
//         phaseController = FindObjectOfType<PhaseController>();
//     }
//
//     void Update()
//     {
//         // If the card is hovered and it's the main phase
//         if (cardHigher.IsHovered && phaseController.CurrentPhase == GamePhase.MainPhase)
//         {
//             // If there is an inactive button, set it active instead of instantiating a new one
//             if (hoverButton != null && !hoverButton.gameObject.activeSelf)
//             {
//                 hoverButton.gameObject.SetActive(true);
//             }
//             else if (hoverButton == null)
//             {
//                 // Instantiate the button at the right hand of the card when the card is hovered
//                 hoverButton = Instantiate(buttonPrefab, new Vector3(transform.position.x + 150, transform.position.y+70, transform.position.z), Quaternion.identity, transform);
//                 hoverButton.onClick.AddListener(HandleClick); // Register the HandleClick method as the button's OnClick event handler
//             }
//         }
//         else
//         {
//             // If the card is not hovered, it's not the main phase, or the button exists, set the button inactive
//             if (hoverButton != null)
//             {
//                 hoverButton.gameObject.SetActive(false);
//             }
//         }
//     }
//
//     // This method will be called when the button is clicked
//     
//     void HandleClick()
//     {
//         Debug.Log("Choose where the rear guard to be called");
//         cardSelected = true;
//         // Store the selected card
//         phaseController.SelectedCard = cardHigher;
//         callCardInMainPhase = true;
//     }
// }
using UnityEngine;
using UnityEngine.UI;

public class MainPhaseControl : MonoBehaviour
{
    [SerializeField] private Button buttonPrefab; // Reference to the button prefab
    [SerializeField] private Button cancelButtonPrefab; // Reference to the cancel button prefab
    private Button hoverButton; // Reference to the instantiated button
    private Button cancelButton; // Reference to the instantiated cancel button
    private CardHigher cardHigher; // Reference to the CardHigher component
    private PhaseController phaseController; // Reference to the PhaseController component
    public static bool cardSelected = false;
    public static bool callCardInMainPhase = false;

    void Start()
    {
        // Get the CardHigher and PhaseController components
        cardHigher = GetComponent<CardHigher>();
        phaseController = FindObjectOfType<PhaseController>();
    }

    void Update()
    {
        // If the card is hovered and it's the main phase
        if (cardHigher.IsHovered && phaseController.CurrentPhase == GamePhase.MainPhase)
        {
            // Handle the hover button
            if (hoverButton != null && !hoverButton.gameObject.activeSelf)
            {
                hoverButton.gameObject.SetActive(true);
            }
            else if (hoverButton == null)
            {
                // Instantiate the hover button
                hoverButton = Instantiate(buttonPrefab, new Vector3(transform.position.x + 150, transform.position.y+70, transform.position.z), Quaternion.identity, transform);
                hoverButton.onClick.AddListener(HandleClick); // Register the HandleClick method as the hover button's OnClick event handler
            }

            // Handle the cancel button
            if (cancelButton != null && !cancelButton.gameObject.activeSelf)
            {
                cancelButton.gameObject.SetActive(true);
            }
            else if (cancelButton == null)
            {
                // Instantiate the cancel button
                cancelButton = Instantiate(cancelButtonPrefab, new Vector3(transform.position.x + 150, transform.position.y, transform.position.z), Quaternion.identity, transform);
                cancelButton.onClick.AddListener(HandleCancelClick); // Register the HandleCancelClick method as the cancel button's OnClick event handler
            }
        }
        else
        {
            // If the card is not hovered, it's not the main phase, or the button exists, set the buttons inactive
            if (hoverButton != null)
            {
                hoverButton.gameObject.SetActive(false);
            }
            if (cancelButton != null)
            {
                cancelButton.gameObject.SetActive(false);
            }
        }
    }

    // This method will be called when the hover button is clicked
    void HandleClick()
    {
        Debug.Log("Choose where the rear guard to be called");
        cardSelected = true;
        // Store the selected card
        phaseController.SelectedCard = cardHigher;
        callCardInMainPhase = true;
    }

    // This method will be called when the cancel button is clicked
    void HandleCancelClick()
    {
        Debug.Log("Cancelled card selection");
        cardSelected = false;
        callCardInMainPhase = false;
 
        cardHigher.HoverLogic();
    }
}