using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    protected GameObject content;
    public GameManager gameManagerPrefab;

    private int players = 2;

    private Button startGameButton;
    private Button addPlayerButton;
    private Button removePlayerButton;

    private List<GameObject> namesObj;
    
    // Start is called before the first frame update
    void Start()
    {
        var buttons = new List<Button>();
        this.GetComponentsInChildren(buttons);
        startGameButton = buttons.Find(b => b.name == "PlayButton");
        startGameButton.onClick.AddListener(StartGame);

        addPlayerButton = buttons.Find(b => b.name == "AddPlayerButton");
        addPlayerButton.onClick.AddListener(AddPlayer);

        removePlayerButton = buttons.Find(b => b.name == "RemovePlayerButton");
        removePlayerButton.onClick.AddListener(RemovePlayer);


        namesObj = new List<GameObject>(GameObject.FindGameObjectsWithTag("Names"));

        content = GameObject.FindGameObjectWithTag("Content");
    }

    // Update is called once per frame
    void Update()
    {
        if (players <= 2) {
            removePlayerButton.interactable = false;
        } else {
            removePlayerButton.interactable = true;
        }

        if (players >= 4) {
            addPlayerButton.interactable = false;
        } else {
            addPlayerButton.interactable = true;
        }

        List<string> names = new List<string>();
        foreach (var nameObj in namesObj) {
            names.Add(nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text);
        }
        startGameButton.interactable = !CheckForMatchingNames(names);
    }


    bool CheckForMatchingNames(List<string> names) {
        bool found = false;
        for (int i = 0; i < names.Count; i++) {
            List<string> newList = new List<string>(names);
            newList.RemoveAt(i);
            if (newList.Contains(names[i])) {
                found = true;
                break;
            }
        }

        return found;
    }


    void StartGame() {
        Debug.Log("Starting");
        var playerFeilds = GameObject.FindGameObjectsWithTag("PlayerFeild");
        var namesObj = GameObject.FindGameObjectsWithTag("Names");
        List<string> names = new List<string>();
        foreach (var nameObj in namesObj) {
            names.Add(nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text);
        }
        var game = Instantiate(gameManagerPrefab);
        game.StartGame(names);
        Destroy(GameObject.FindGameObjectWithTag("MainMenu"));
    }

    void AddPlayer() {
        Debug.Log("Adding");
        var playerFeilds = GameObject.FindGameObjectsWithTag("PlayerFeild");
        if (playerFeilds.Length == 4) {
            return;
        }
        players++;
        var lastPayerFeild = playerFeilds[playerFeilds.Length - 1];
        var new_feild = Instantiate(lastPayerFeild);
        new_feild.GetComponent<RectTransform>().SetParent(content.transform);
        new_feild.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

        new_feild.GetComponentInChildren<TMPro.TMP_InputField>().text = $"Player {players}";

        namesObj.Add(new_feild);
    }

    void RemovePlayer() {
        Debug.Log("Removing");
        var playerFeilds = GameObject.FindGameObjectsWithTag("PlayerFeild");
        if (playerFeilds.Length <= 2) {
            return;
        }
        players--;
        var lastPayerFeild = playerFeilds[playerFeilds.Length - 1];
        namesObj.RemoveAt(playerFeilds.Length - 1);
        Destroy(lastPayerFeild);
    }
}
