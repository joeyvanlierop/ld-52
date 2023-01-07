using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public int cost;
    public int cardID; //unique number to distinquish each individual card object
    public int playerDeck; // which deck does this card belong to
    public int cardLocation; //is this card in the draw pile, a players hand or the discard 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public abstract void ActionPerformed(); //performs card action and then calls removeFromDeck to put card in discard

    public abstract void cardGrowBig(); //function for card to grow bigger when hovered over

    public abstract void removeFromDeck(); //puts card in discard pile

    public abstract void addToDeck(); //adds card to deck, changes cardLocation variable.




}
