using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[System.Serializable]
public class WeightCardPrefab {
    public int weight;
    public Card prefab;
}

public class Deck : MonoBehaviour
{

    public List<WeightCardPrefab> weightCardPrefabs;
    public int cardCount;
    public List<Card> cardList;


    void PopulateDeck() {
        IEnumerable<int> e = from weightCardPrefab in weightCardPrefabs select weightCardPrefab.weight;
        for (int i = 0; i < cardCount; i++) {
            cardList.Add(Instantiate(GetRandomCardByWeight(e.Sum())));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card GetRandomCardByWeight(int totalWeight)
        {
            // totalWeight is the sum of all brokers' weight
            System.Random r = new System.Random(); 
            int randomNumber = r.Next(0, totalWeight);

            foreach (WeightCardPrefab prefab in weightCardPrefabs)
            {
                if (randomNumber <= prefab.weight)
                {
                    return prefab.prefab;
                }

                randomNumber = randomNumber - prefab.weight;
            }

            return default(Card);
        }



}
