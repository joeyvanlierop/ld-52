using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour, TimerObserver
{
    // Prefabs
    public Player playerPrefab;
    public Canvas transitionScreenPrefab;
    public Canvas generalUiPrefab;
    public Timer turnTimerPrefab;
    public Deck deckPrefab;
    
    // Members
    public float kDefaultTurnTimer = 50;
    public float transitionTime = 5;
    public int playerCount = 4;
    public List<Player> players;
    public Canvas transitionScreen;
    public Canvas generalUi;
    public Timer timer;
    public Deck deck;
    


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

        timer = Instantiate(turnTimerPrefab);
        timer.RegisterObserver(this);

        transitionScreen = Instantiate(transitionScreenPrefab);
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,0);
        transitionScreen.GetComponentInChildren<Button>().onClick.AddListener(Transition);


        generalUi = Instantiate(generalUiPrefab);
        List<Button> buttons = new List<Button>();
        generalUi.GetComponentsInChildren<Button>(buttons);
        buttons.Find(b => b.name == "EndTurnButton").onClick.AddListener(Transition);
        buttons.Find(b => b.name == "DrawCardButton").onClick.AddListener(DrawCard);
        generalUi.enabled = false;

        deck = Instantiate(deckPrefab);
        deck.PopulateDeck();
    


        StartTransition(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    void StartTransition(bool first = false) {
        generalUi.enabled = false;
        transitionScreen.enabled = true;
        timer.StartTimer(transitionTime);
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,255);
        string text;
        if (first) {
            text = $"{players[currentPlayerIndex].playerName} starts!";
        } else {
            text = $"Move away from the screen.\n It is now {players[currentPlayerIndex].playerName}'s turn!";
        }
        transitionScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = text;
    }


    void EndTransition() {
        transitionScreen.enabled = false;
        generalUi.enabled = true;
        transitionScreen.GetComponent<Image>().color = new Color(0,0,0,0);
        timer.StartTimer(kDefaultTurnTimer);
        transitionScreen.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "";
    }


    public void OnTimerEnd() {
        Transition();
    }

    public void DrawCard() {
        var card = deck.DrawNextCard();
        Debug.Log($"even after {card.name}");
        players[currentPlayerIndex].DrawCard(card);
        Debug.Log("Draw");
    }


    public void Transition() {
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
