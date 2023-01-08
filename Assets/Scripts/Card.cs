using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    private LineRenderer lr;
    private Vector2 startPosition;
    private Vector2 endPosition;

    public Material redMaterial;
    public Material greenMaterial;
    public float width = 0.25f;
    
    public int cost;
    public Vector2 scaleChange; // creates scale change variable (values assigned in unity)
    public bool mouseOver;
    public Vector3 originalPOS; //original card position
    public int originalSort; //original card sorting order
    public Vector3 hoverMovement; // how much card moves when card hovered over

    protected void Start()
    {
        lr = gameObject.AddComponent(typeof(LineRenderer)) as LineRenderer;
        lr.widthMultiplier = width;
        lr.enabled = false;
        lr.numCapVertices = 20;
        lr.sortingOrder = 10;
    }

    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if (lr.enabled)
        {
            HighlightEffect hf = GameObject.FindGameObjectWithTag("CropManager").GetComponent<HighlightEffect>();
            Vector3Int position = hf.GetHighlightPosition();
            if (hf.IsValidTile(position))
                lr.material = greenMaterial;
            else
                lr.material = redMaterial;
            
            startPosition = gameObject.transform.position;
            lr.SetPosition(0, startPosition);
            endPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(1, endPosition);
        }
    }

    //performs card action
    public abstract void ActionPerformed(Vector3Int position);


    public void OnMouseEnter()
    {
        //getting original position and sorting order of card
        originalPOS = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        originalSort = GetComponent<SpriteRenderer>().sortingOrder;

        // makes card bigger when mouse first passes over it
        transform.localScale = new Vector2(transform.localScale.x + scaleChange.x, transform.localScale.y + scaleChange.y);

        // moves card to be fully on screen
        transform.position = new Vector3(originalPOS.x + hoverMovement.x, originalPOS.y + hoverMovement.y, originalPOS.z + hoverMovement.z);
        
        GetComponent<SpriteRenderer>().sortingOrder = 100;
    }

    public void OnMouseExit()
    {
        // makes card smaller when mouse leaves it
        transform.localScale = new Vector2(transform.localScale.x - scaleChange.x, transform.localScale.y - scaleChange.y);

        // moves card to original postion
        transform.position = originalPOS;
        GetComponent<SpriteRenderer>().sortingOrder = originalSort;
    }

    // // when mouse is over the card
    // public void OnMouseOver()
    // {
    //     //if mouse clicked on card it calls the action perfomed function
    //     if(Input.GetMouseButtonDown(0)){
    //         ActionPerformed();
    //     }
    // }

    void OnMouseDown()
    {
        lr.enabled = true;
    }
    
    void OnMouseUp()
    {
        lr.enabled = false;
        HighlightEffect hf = GameObject.FindGameObjectWithTag("CropManager").GetComponent<HighlightEffect>();
        Vector3Int position = hf.GetHighlightPosition();
        if (!hf.IsValidTile(position))
            return;
        ActionPerformed(position);
    }
}
