using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Hand handPrefab;

    public float actionPoints;

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



    public bool PlayCard(Card card) {
        var new_points = actionPoints - card.actionPoints;
        Debug.Log($"{playerName} {new_points} {actionPoints}");
        if (new_points < 0) {
            return false;
        }
        actionPoints = new_points;
        return true;
    }




    public void DrawCard(Card card) {
        hand.AddCard(card, this);
    }
}
