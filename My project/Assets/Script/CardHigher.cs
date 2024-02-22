using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardHigher : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField]private float hoverRaiseAmount = 30f; // The amount to raise the card when hovered
    private bool isHovered=false; // The amount to raise the card when hovered;

    public bool IsHovered
    {
        get => isHovered;
        set => isHovered = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Original position: " + originalPosition);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method is called when the mouse pointer enters the object
    public void OnPointerClick(PointerEventData pointerEventData)    {
        if (isHovered==false)
        {
            isHovered= true;
            transform.position = new Vector3(transform.position.x, transform.position.y + hoverRaiseAmount, transform.position.z);
            Debug.Log("Toggle to true: " + isHovered);
        }
        else
        {
            isHovered = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - hoverRaiseAmount, transform.position.z);
            // Debug.Log("Toggle to false: " + isHovered);
            
        }

        
    }
    
    public void OnPointerEnter(PointerEventData pointerEventData)    {
        // Debug.Log("Pointer Entered: " + isHovered);


        
    }

    // This method is called when the mouse pointer exits the object

}