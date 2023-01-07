using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int cost;
    // public int cardID; //unique number to distinquish each individual card object
    // public int playerDeck; // which deck does this card belong to
    // public int cardLocation; //is this card in the draw pile (0), a players hand (1) or the discard (2)
    public Vector2 scaleChange; // creates sccale change variable (values assigned in unity)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public abstract void ActionPerformed(); //performs card action and then calls removeFromDeck to put card in discard

    public void cardGrowBig()
    {
        //card gets bigger when function called
        transform.localScale += scaleChange;
    }

    // public void removeFromDeck()
    // {
    //     cardLocation = 2;
    // }

    // public void addToDeck()
    // {
    //     //adds card to deck, changes cardLocation variable.

    // }



}
