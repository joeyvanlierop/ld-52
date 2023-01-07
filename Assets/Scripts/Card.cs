using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int cost;
    public Vector2 scaleChange; // creates sccale change variable (values assigned in unity)
    public bool mouseOver;
    public Vector3 originalPOS; //original card position
    public Vector3 hoverMovement; // how much card moves when card hovered over
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //performs card action
    public abstract void ActionPerformed(); 

    public void OnMouseEnter()
    {
        //getting original position of card
        originalPOS = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // makes card bigger when mouse first passes over it
        transform.localScale = new Vector2(transform.localScale.x + scaleChange.x, transform.localScale.y + scaleChange.y);

        // moves card to be fully on screen
        transform.position = new Vector3(originalPOS.x + hoverMovement.x, originalPOS.y + hoverMovement.y, originalPOS.z + hoverMovement.z);
    }

    public void OnMouseExit()
    {
        // makes card smaller when mouse leaves it
        transform.localScale = new Vector2(transform.localScale.x - scaleChange.x, transform.localScale.y - scaleChange.y);

        // moves card to original postion
        transform.position = originalPOS;
    }



}
