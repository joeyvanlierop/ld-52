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
            Debug.Log(nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text);
            names.Add(nameObj.GetComponentInChildren<TMPro.TMP_InputField>().text);
        }
        var game = Instantiate(gameManagerPrefab);
        game.StartGame(names);
        Destroy(GameObject.FindGameObjectWithTag("MainMenu"));
    }

    void AddPlayer() {
        Debug.Log("Adding");
        var playerFeilds = GameObject.FindGameObjectsWithTag("PlayerFeild");
        var lastPayerFeild = playerFeilds[playerFeilds.Length - 1];
        var new_feild = Instantiate(lastPayerFeild);
        new_feild.GetComponent<RectTransform>().SetParent(content.transform);
        
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
