using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> cards;
    public float spacing = 1;
    public float yOffset = 1;
    public float cardWidth = 3;
    public Animator movement;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.E)) sendHandToNarnia();
        if (Input.GetKey(KeyCode.R)) bringHandFromNarnia();
    }

    private void Layout()
    {
        var stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        //loop to draw card game objects on the screen
        for (var i = 0; i < cards.Count; i++)
        {
            // instantiates card object
            // Card c = Instantiate(cards[i], gameObject.transform, true);
            var c = cards[i];

            //moves cards to appropriate location and spacing
            c.transform.position =
                new Vector3(cardWidth * (cards.Count / 2 - i) * (spacing / cards.Count), stageDimensions.y + yOffset,
                    0);
            c.GetComponent<SpriteRenderer>().sortingOrder = i;
            GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            c.GetComponent<SpriteRenderer>().color =
                new Color(1, 1, 1, gm.players[gm.currentPlayerIndex].actionPoints >= c.actionPoints ? 1f : 0.3f);
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
        var renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers) renderer.enabled = true;
        var colliders = GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders) collider.enabled = true;
    }

    public void Hide()
    {
        var renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (var renderer in renderers) renderer.enabled = false;
        var colliders = GetComponentsInChildren<BoxCollider2D>();
        foreach (var collider in colliders) collider.enabled = false;
    }

    public void AddCard(Card card, Player player)
    {
        Debug.Log($"Points After {card.actionPoints}");
        var c = Instantiate(card);
        c.RegisterPlayer(player);
        c.transform.SetParent(transform);
        cards.Add(c);
        Layout();
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
        Destroy(card.gameObject);
        Layout();
    }
}