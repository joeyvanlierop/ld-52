using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Card> cards;
    public float spacing = 1;
    public float yOffset = 1;
    public float cardWidth = 3;
    public Animator movement;

    // Start is called before the first frame update
    void Start()
    {
        // Layout();
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
            // Card c = Instantiate(cards[i], gameObject.transform, true);
            Card c = cards[i];

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


    public void Show() 
    {
        var renderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers) {
            renderer.enabled = true;
        }
        var colliders = this.GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders) {
            collider.enabled = true;
        }
    }

    public void Hide() 
    {
        var renderers = this.GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers) {
            renderer.enabled = false;
        }
        var colliders = this.GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders) {
            collider.enabled = false;
        }
    }

    public void AddCard(Card card) {
        Debug.Log($"AGGG {card.name}");
        var c = Instantiate(card);
        c.transform.SetParent(this.transform);
        cards.Add(c);

        Layout();
    }
}



