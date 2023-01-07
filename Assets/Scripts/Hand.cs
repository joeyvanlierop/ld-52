using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public List<Card> cards;
    public Vector3 startingLocation;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cards.Count; i++ )
        {
            GameObject c = Instantiate(cards[i]) as GameObject;
            c.transform.position = new Vector3(startingLocation.x+i,startingLocation.y,startingLocation+(i*0.01));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
