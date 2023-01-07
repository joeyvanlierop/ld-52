using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float time;
    public bool timerStarted = false;

    public List<GameObject> observers; 

    // public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted) {
            time -= Time.deltaTime;
        }
    }

    public void StartTimer() {
        timerStarted = true;
    } 

    public void RegisterObserver(GameObject observer) {
        observers.Add(observer);
    }

    public void NotifyObservers() {
        
    }
}
