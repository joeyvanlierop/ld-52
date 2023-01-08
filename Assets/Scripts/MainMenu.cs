using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    protected GameObject content;
    public GameManager gameManagerPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        var buttons = new List<Button>();
        this.GetComponentsInChildren(buttons);
        buttons.Find(b => b.name == "PlayButton").onClick.AddListener(StartGame);
        buttons.Find(b => b.name == "AddPlayerButton").onClick.AddListener(AddPlayer);
        buttons.Find(b => b.name == "RemovePlayerButton").onClick.AddListener(RemovePlayer);
        content = GameObject.FindGameObjectWithTag("Content");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        var lastPayerFeild = playerFeilds[playerFeilds.Length - 1];
        var new_feild = Instantiate(lastPayerFeild);
        new_feild.GetComponent<RectTransform>().SetParent(content.transform);
        new_feild.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);

        // var namesObj = GameObject.FindGameObjectsWithTag("Names");
        // List<string> names = new List<string>();
        // int biggest_num = 0;
        // foreach (var nameObj in namesObj) {
        //     var name = nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text;
        //     if (name.Contains("Player ")) {
        //         resultString = Int32.Parse(System.Text.RegularExpressions.Regex.Match(name, @"\d+").Value);
        //     }
        //     names.Add(nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text);
            
        // }
        // if (names.Contains(new_feild.GetComponentInChildren<TMPro.TMP_InputField>().text)) {
        //     new_feild.GetComponentInChildren<TMPro.TMP_InputField>().text = "Player "
        // }
        // new_feild.GetComponentInChildren<TMPro.TMP_InputField>().text = lastPayerFeild
    }

    void RemovePlayer() {
        Debug.Log("Removing");
        var playerFeilds = GameObject.FindGameObjectsWithTag("PlayerFeild");
        if (playerFeilds.Length <= 2) {
            return;
        }
        var lastPayerFeild = playerFeilds[playerFeilds.Length - 1];
        Destroy(lastPayerFeild);
    }
}
