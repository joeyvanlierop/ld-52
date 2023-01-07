using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatCard : Card
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public override void ActionPerformed() {

    } //performs card action and then calls removeFromDeck to put card in discard

    public override void removeFromDeck() { 

    } //puts card in discard pile

    public override void addToDeck() { 

    } //adds card to deck, changes cardLocation variable.

}
