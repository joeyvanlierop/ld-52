using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class GameManager : MonoBehaviour
{
    public float kDefaultTimer = 30;

    public int playerCount = 4;

    public List<Player> players;

    public Player playerPrefab;

    private int currentPlayerIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerCount; i++) {
            players.Add(Instantiate(playerPrefab));
        }

        for (int i = 0; i < players.Count; i++) {
         Player temp = players[i];
         int randomIndex = Random.Range(i, players.Count);
         players[i] = players[randomIndex];
         players[randomIndex] = temp;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
