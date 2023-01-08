using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    public bool timerStarted;

    public List<TimerObserver> observers = new();

    // Update is called once per frame
    private void Update()
    {
        if (timerStarted)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                timerStarted = false;
                time = 0;
                NotifyObservers();
            }
        }
    }

    public void StartTimer(float to_set)
    {
        time = to_set;
        timerStarted = true;
    }

    public void PauseTimer()
    {
        timerStarted = false;
    }

    public void RegisterObserver(TimerObserver observer)
    {
        observers.Add(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers) observer.OnTimerEnd();
    }
}