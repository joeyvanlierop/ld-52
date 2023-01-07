using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornCard : Card
{

    private bool switchKey = true;
    private Vector3 scaleOriginal;
    // Start is called before the first frame update
    void Start()
    {
           scaleOriginal = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            if(switchKey == true){
                cardGrowBig();
            }

            else
            {
                transform.localScale = scaleOriginal;
            }
            switchKey = !switchKey;
        }
    }

    public override void ActionPerformed()
    {

    } //performs card action and then calls removeFromDeck to put card in discard

    public override void removeFromDeck()
    {

    } //puts card in discard pile

    public override void addToDeck()
    {

    } //adds card to deck, changes cardLocation variable.
}
