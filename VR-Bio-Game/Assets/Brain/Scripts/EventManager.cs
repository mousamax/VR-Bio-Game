using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    enum Events
    {
        Exercises = 0,
        TrafficJam = 1,
        EatProkly = 2,
        None = 3
    }

    public static EventManager _eventManager;
    private Events _currentEvent;
    public int events;
    public AudioSource EventNotification;
    private bool _isDone;
    private DateTime _nextEventStart;
    public int _eventDuration = 10;
    public bool finishedjob = true;

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
    }

    void Update()
    {
        if (_eventManager == null)
        {
            Debug.Log("Renew EventManager");
            _eventManager = this;
        }
        if (!GameManager._gameManager.OnTutorialMode)
        {
            events = (int)_currentEvent;
            _isDone = finishedjob;
            if (DateTime.Now.CompareTo(_nextEventStart) >= 0)
            {
                _isDone = true; ;
            }
            if (_isDone || _currentEvent == Events.None)
            {
                EventNotification.Play();
                ActiveteAnotherEvent();
                _isDone = false;
                _nextEventStart = DateTime.Now.AddSeconds(_eventDuration);
            }
            finishedjob = _isDone;
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
    }

    public void setIsDone(bool val)
    {
        _isDone = val;
    }
    public bool getIsDone()
    {
        return _isDone;
    }

    public int getCurrentEvent()
    {
        return (int)_currentEvent;
    }
    public void setCurrentEvent(int ev)
    {
        _currentEvent = (Events)ev;
    }
    public int getNoneEvent()
    {
        return (int)Events.None;
    }
}
