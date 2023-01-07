using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<GameObject> cards;
    public float spacing = 1;
    public float yOffset = 1;
    public float cardWidth = 3;
    public Animator movement;

    // Start is called before the first frame update
    void Start()
    {
        Layout();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            sendHandToNarnia();
        }
        if (Input.GetKey(KeyCode.R))
        {
            bringHandFromNarnia();
        }
    }

    void Layout()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        
        //loop to draw card game objects on the screen
        for (int i = 0; i < cards.Count; i++)
        {
            // instantiates card object
            GameObject c = Instantiate(cards[i], gameObject.transform, true);

            //moves cards to appropriate location and spacing
            c.transform.position =
                new Vector3(cardWidth * (cards.Count / 2 - i) * (spacing / cards.Count), stageDimensions.y + yOffset, 0);
            c.GetComponent<SpriteRenderer>().sortingOrder = i;
        }
    }

    // move hand offsceen function
    public void sendHandToNarnia()
    {
        
    }

    // move hand to the screen
    public void bringHandFromNarnia()
    {
      
    }
}



