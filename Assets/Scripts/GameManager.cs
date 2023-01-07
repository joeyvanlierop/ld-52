using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour, TimerObserver
{
    // Prefabs
    public Player playerPrefab;
    public Canvas transitionScreenPrefab;
    public Timer turnTimerPrefab;

    // Members
    public float kDefaultTurnTimer = 5;
    public int playerCount = 4;
    public List<Player> players;
    public Canvas transitionScreen;
    public Timer timer;
    public float transitionTime = 5;


    private int currentPlayerIndex = 0;
    private string[] names = {"joe", "mama", "ben", "dover"};
    private bool inTransition = true;


    // Start is called before the first frame update
    void Start()
    {
        // Instantiate
        for (int i = 0; i < playerCount; i++) {
            Player player = Instantiate(playerPrefab);
            player.playerName = names[i];
            players.Add(player);
        }

        // Randomize
        for (int i = 0; i < players.Count; i++) {
         Player temp = players[i];
         int randomIndex = Random.Range(i, players.Count);
         players[i] = players[randomIndex];
         players[randomIndex] = temp;
        }

        transitionScreen = Instantiate(transitionScreenPrefab);
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,0);

        timer = Instantiate(turnTimerPrefab);
        timer.RegisterObserver(this);


        StartTransition(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void StartTransition(bool first = false) {
        timer.StartTimer(transitionTime);
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,255);
        string text;
        if (first) {
            text = $"{players[currentPlayerIndex].playerName} starts!";
        } else {
            text = $"Move away from the screen.\n It is now {players[currentPlayerIndex].playerName}'s turn!";
        }
        transitionScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text;
        // transitionScreen.enabled = true;
        Debug.Log("Start");
    }


    void EndTransition() {
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,0);
        timer.StartTimer(kDefaultTurnTimer);
        transitionScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "KSSSS";
        Debug.Log("End");
    }


    public void OnTimerEnd() {
        if (!inTransition) {
            currentPlayerIndex++;
            if (currentPlayerIndex == playerCount) {
                currentPlayerIndex = 0;
            }
            StartTransition();
        } else {
            EndTransition();
        }
        inTransition = !inTransition;
    }

    
}
