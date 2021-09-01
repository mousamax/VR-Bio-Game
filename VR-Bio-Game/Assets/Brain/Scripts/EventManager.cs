using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    enum Events
    {
        Exercises = 0,
        Eat = 1,
        Disease = 2,
        None = 4
    }

    public static EventManager _eventManager;
    private Events _currentEvent;
    public int events;
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
                GameManager._gameManager.ChangeStatus(0, -30);
                break;
            case 1:
                _currentEvent = Events.Eat;
                GameManager._gameManager.ChangeStatus(1, -30);
                break;
            case 2:
                _currentEvent = Events.Disease;
                GameManager._gameManager.ChangeStatus(2, -30);
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
