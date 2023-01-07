using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float time;
    public bool timerStarted = false;

    public List<TimerObserver> observers = new List<TimerObserver>(); 

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
            if (time < 0) {
                timerStarted = false;
                time = 0;
                NotifyObservers();
            }
        }
    }

    public void StartTimer(float to_set) {
        time = to_set;
        timerStarted = true;
    }

    public void PauseTimer() {
        timerStarted = false;
    } 

    public void RegisterObserver(TimerObserver observer) {
        observers.Add(observer);
    }

    public void NotifyObservers() {
        foreach (TimerObserver observer in observers) {
            observer.OnTimerEnd();
        }
    }
}
