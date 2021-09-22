using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Events
{
    Exercises = 0,
    TrafficJam = 1,
    EatProkly = 2,
    None = 3
}
public enum Difficulty
{
    Easy = 0,
    Normal = 1,
    Hard = 2,
    Nightmare = 3
}
public class EventManager : MonoBehaviour
{
    public static EventManager _eventManager;
    private Events _currentEvent;
    public int events;
    public AudioSource EventNotification;
    private bool _isDone;
    private DateTime _nextEventStart;
    public DateTime NextEventStart;
    public int _eventDuration = 10;
    public EventDiff[] EventsDifficulty = new EventDiff[]{
        new EventDiff(),
        new EventDiff(),
        new EventDiff(),
    };
    public int remainTime;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_eventManager == null)
        {
            _eventManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _eventManager = this;
        _currentEvent = Events.None;
        _isDone = true;
        _nextEventStart = DateTime.Now.AddSeconds(_eventDuration);
        remainTime = _eventDuration;
        NextEventStart = _nextEventStart;
    }

    void Update()
    {
        NextEventStart = _nextEventStart;
        if (_eventManager == null)
        {
            Debug.Log("Renew EventManager");
            _eventManager = this;
        }
        if (!Tutorial._Tutorial.OnTutorialMode)
        {
            events = (int)_currentEvent;
            remainTime = _nextEventStart.Subtract(DateTime.Now).Seconds;
            if (DateTime.Now.CompareTo(_nextEventStart) >= 0 || _currentEvent == Events.None)
            {
                EventNotification.Play();
                ActiveteAnotherEvent();

                Debug.Log("first Event Counter: " + EventsDifficulty[0].EventCounter + " first Event Difficulty: " + EventsDifficulty[0].EventDifficulty);
                Debug.Log("Second Event Counter: " + EventsDifficulty[1].EventCounter + " Second Event Difficulty: " + EventsDifficulty[1].EventDifficulty);
                Debug.Log("Third Event Counter: " + EventsDifficulty[2].EventCounter + " Third Event Difficulty: " + EventsDifficulty[2].EventDifficulty);

                _isDone = false;
                _nextEventStart = DateTime.Now.AddSeconds(_eventDuration);
            }
        }
        else
        {
            _nextEventStart = DateTime.Now.AddSeconds(remainTime);
        }
    }

    void ActiveteAnotherEvent()
    {
        switch (UnityEngine.Random.Range(0, 1000) % 3)
        {
            case 0:
                _currentEvent = Events.Exercises;
                GameManager._gameManager.ChangeStatus(0, -20);
                GameManager._gameManager.ChangeStatus(1, 10);
                GameManager._gameManager.ChangeStatus(2, 15);
                break;
            case 1:
                _currentEvent = Events.TrafficJam;
                GameManager._gameManager.ChangeStatus(0, -15);
                GameManager._gameManager.ChangeStatus(2, -20);
                break;
            case 2:
                _currentEvent = Events.EatProkly;
                GameManager._gameManager.ChangeStatus(1, -20);
                GameManager._gameManager.ChangeStatus(2, 20);
                break;
            default:
                break;
        }

        EventsDifficulty[(int)_currentEvent].EventCounter++;
        if (EventsDifficulty[(int)_currentEvent].EventDifficulty != Difficulty.Nightmare)
        {
            EventsDifficulty[(int)_currentEvent].EventDifficulty =
            EventsDifficulty[(int)_currentEvent].EventCounter > 10 ? EventsDifficulty[(int)_currentEvent].EventDifficulty = Difficulty.Nightmare :
            EventsDifficulty[(int)_currentEvent].EventCounter > 6 ? EventsDifficulty[(int)_currentEvent].EventDifficulty = Difficulty.Hard :
            EventsDifficulty[(int)_currentEvent].EventCounter > 3 ? EventsDifficulty[(int)_currentEvent].EventDifficulty = Difficulty.Normal :
            EventsDifficulty[(int)_currentEvent].EventDifficulty;
        }
    }

    public void setIsDone(bool val)
    {
        _isDone = val;
    }
    public bool getIsDone()
    {
        return _isDone;
    }

    // public int GetCurrentEvent()
    // {
    //     return (int)_currentEvent;
    // }
    public void setCurrentEvent(int ev)
    {
        _currentEvent = (Events)ev;
    }
    public int getNoneEvent()
    {
        return (int)Events.None;
    }

    public Difficulty GetEventDifficulty()
    {
        return EventsDifficulty[(int)_currentEvent].EventDifficulty;
    }
    public Events GetCurrentEvent()
    {
        return _currentEvent;
    }
}
public class EventDiff
{
    public int EventCounter;
    public Difficulty EventDifficulty;

    public EventDiff()
    {
        EventCounter = 0;
        EventDifficulty = Difficulty.Easy;
    }
}