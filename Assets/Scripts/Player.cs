using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float ActionPoints = 0;

    public float turnTime;

    public Hand hand;

    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DrawCard(Card card) {
        hand.AddCard(card);
    }
}
