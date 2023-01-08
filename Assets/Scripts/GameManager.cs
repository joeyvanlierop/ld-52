using System.Collections.Generic;
using TMPro;
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
    public GameObject pointsTextPrefab;

    // Members
    public float kDefaultTurnTimer = 50;
    public float transitionTime = 5;
    public int playerCount = 4;
    public int actionPointsTurnRefresh = 3;
    public List<Player> players;
    public Canvas transitionScreen;
    public Canvas generalUi;
    public Timer timer;
    public Deck deck;
    public CropManager cropManager;
    public HighlightEffect highlightEffect;
    public TextMeshPro actionPointsText;

    public int currentPlayerIndex;
    private bool inTransition = true;
    private readonly string[] names = { "joe", "mama", "ben", "dover" };
    private readonly List<GameObject> pointsTexts = new();


    // Start is called before the first frame update
    private void Start()
    {
        // Instantiate
        for (var i = 0; i < playerCount; i++)
        {
            var player = Instantiate(playerPrefab);
            player.playerName = names[i];
            players.Add(player);
        }

        // Randomize
        for (var i = 0; i < players.Count; i++)
        {
            var temp = players[i];
            var randomIndex = Random.Range(i, players.Count);
            players[i] = players[randomIndex];
            players[randomIndex] = temp;
        }

        timer = Instantiate(turnTimerPrefab);
        timer.RegisterObserver(this);

        transitionScreen = Instantiate(transitionScreenPrefab);
        transitionScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        transitionScreen.GetComponentInChildren<Button>().onClick.AddListener(Transition);


        generalUi = Instantiate(generalUiPrefab);
        var buttons = new List<Button>();
        generalUi.GetComponentsInChildren(buttons);
        buttons.Find(b => b.name == "EndTurnButton").onClick.AddListener(Transition);
        buttons.Find(b => b.name == "DrawCardButton").onClick.AddListener(DrawCard);
        generalUi.enabled = false;

        deck = Instantiate(deckPrefab);
        deck.PopulateDeck();

        cropManager = FindObjectOfType<CropManager>();
        highlightEffect = FindObjectOfType<HighlightEffect>();

        // Add points UI elements
        for (var i = 0; i < players.Count; i++)
        {
            var player = players[i];
            var pointsText = Instantiate(pointsTextPrefab, new Vector3(0, -i, 0), Quaternion.identity);
            var rect = pointsText.GetComponent<RectTransform>();
            var text = pointsText.GetComponent<TextMeshPro>();
            pointsText.transform.SetParent(generalUi.transform);
            text.text = $"{player.playerName}: 0";
            pointsText.name = player.playerName;
            pointsTexts.Add(pointsText);
        }

        StartTransition(true);
    }

    public void OnTimerEnd()
    {
        Transition();
    }

    private void StartTransition(bool first = false)
    {
        generalUi.enabled = false;
        highlightEffect.active = false;
        transitionScreen.enabled = true;
        timer.StartTimer(transitionTime);
        transitionScreen.GetComponent<Image>().color = new Color(0, 0, 0, 255);
        string text;
        if (first)
            text = $"{players[currentPlayerIndex].playerName} starts!";
        else
            text = $"Move away from the screen.\n It is now {players[currentPlayerIndex].playerName}'s turn!";
        transitionScreen.GetComponentInChildren<TextMeshProUGUI>().text = text;
        cropManager.OnTurn();
    }


    private void EndTransition()
    {
        transitionScreen.enabled = false;
        generalUi.enabled = true;
        transitionScreen.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        timer.StartTimer(kDefaultTurnTimer);
        transitionScreen.GetComponentInChildren<TextMeshProUGUI>().text = "";
        Debug.Log($"{players[currentPlayerIndex].playerName}'s points: {players[currentPlayerIndex].actionPoints}");
        highlightEffect.active = true;
        players[currentPlayerIndex].ShowHand();
        players[currentPlayerIndex].actionPoints += actionPointsTurnRefresh;
    }

    public void DrawCard()
    {
        var card = deck.DrawNextCard();
        var player = players[currentPlayerIndex];
        players[currentPlayerIndex].DrawCard(card);
    }


    public void Transition()
    {
        if (!inTransition)
        {
            players[currentPlayerIndex].HideHand();
            currentPlayerIndex++;
            if (currentPlayerIndex == playerCount) currentPlayerIndex = 0;
            StartTransition();
        }
        else
        {
            EndTransition();
        }

        inTransition = !inTransition;
    }


    public void NotifyHarvest(float points, int owner)
    {
        players[owner].points += points;
        pointsTexts[owner].GetComponent<TextMeshPro>().text = $"{players[owner].playerName}: {players[owner].points}";
    }



    public void NotifyActionPointsChanged() {
        Debug.Log($"{players[currentPlayerIndex].playerName}'s points: {players[currentPlayerIndex].actionPoints}");
    }
}