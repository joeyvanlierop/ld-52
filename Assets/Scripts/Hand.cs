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

    // Start is called before the first frame update
    void Start()
    {
        Layout();
    }

    void Layout()
    {
        Vector3 stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject c = Instantiate(cards[i]);
            c.transform.position =
                new Vector3(cardWidth * (cards.Count / 2 - i) * (spacing / cards.Count), stageDimensions.y + yOffset, 0);
            c.GetComponent<SpriteRenderer>().sortingOrder = i;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
    }
}