using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

[Serializable]
public class WeightCardPrefab
{
    public int weight;
    public Card prefab;
}

public class Deck : MonoBehaviour
{
    public List<WeightCardPrefab> weightCardPrefabs;
    public int cardCount;
    public List<Card> cardPrefabList;

    public void PopulateDeck()
    {
        var e = from weightCardPrefab in weightCardPrefabs select weightCardPrefab.weight;
        for (var i = 0; i < cardCount; i++) cardPrefabList.Add(GetRandomCardByWeight(e.Sum()));
    }

    public Card DrawNextCard()
    {
        if (cardPrefabList.Count == 0) return null;
        var card = cardPrefabList[0];
        cardPrefabList.RemoveAt(0);
        return card;
    }

    public Card GetRandomCardByWeight(int totalWeight)
    {
        // totalWeight is the sum of all brokers' weight
        var r = new Random();
        var randomNumber = r.Next(0, totalWeight);

        foreach (var prefab in weightCardPrefabs)
        {
            if (randomNumber <= prefab.weight) return prefab.prefab;

            randomNumber = randomNumber - prefab.weight;
        }

        return default;
    }
}