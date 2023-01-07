using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<GameObject> cards;
    public Vector3 startingLocation;
    public float spacing = 1;

    // Start is called before the first frame update
    void Start()
    {
        Layout();
    }

    void Layout()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject c = Instantiate(cards[i]);
            c.transform.position =
                new Vector3(startingLocation.x + i * spacing, startingLocation.y, 0);
            c.GetComponent<SpriteRenderer>().sortingOrder = i;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
    }
}