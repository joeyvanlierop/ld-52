using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand handPrefab;

    public float ActionPoints = 0;

    public float turnTime;

    public Hand hand;

    public string playerName;

    public float points;

    // Start is called before the first frame update
    void Start()
    {
        hand = Instantiate(handPrefab);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void HideHand() {
        hand.Hide();
    }

    public void ShowHand() {
        hand.Show();
    }




    public void DrawCard(Card card) {
        hand.AddCard(card);
    }
}
