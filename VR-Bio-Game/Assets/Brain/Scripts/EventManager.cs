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
    void Start()
    {
        _eventManager = this;
        _currentEvent = Events.None;
        _isDone = true;
        _nextEventStart = DateTime.Now.AddSeconds(_eventDuration);
    }

    void Update()
    {
        events = (int)_currentEvent;
        _isDone = finishedjob;
        Debug.Log(DateTime.Now.CompareTo(_nextEventStart));
        if (DateTime.Now.CompareTo(_nextEventStart) >= 0)
        {
            Debug.Log("now " + DateTime.Now);
            _isDone = true; ;
        }
        if (_isDone || _currentEvent == Events.None)
        {
            ActiveteAnotherEvent();
            _isDone = false;
            _nextEventStart = DateTime.Now.AddSeconds(_eventDuration);
            Debug.Log("next " + _nextEventStart);
        }
        finishedjob = _isDone;
    }

    void ActiveteAnotherEvent()
    {
        switch (UnityEngine.Random.Range(0, 1000) % 3)
        {
            case 0:
                _currentEvent = Events.Exercises;
                break;
            case 1:
                _currentEvent = Events.Eat;
                break;
            case 2:
                _currentEvent = Events.Disease;
                break;
            default:
                break;
        }
        Debug.Log(_currentEvent);
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
    public int getNoneEvent()
    {
        return (int)Events.None;
    }
}
