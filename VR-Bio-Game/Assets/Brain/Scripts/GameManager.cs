using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    private int _respirationStatus = 100;
    private int _digestionStatus = 100;
    private int _ImmuneStatus = 100;
    private DateTime _nextStateDecrease;
    public float StateDecreaseCoolTime = 2.5f;

    public int DecreaseStatusRate = 1;
    public GameObject TutorialTablet;
    public int respo, digestive, immune;
    public static DateTime GameStartTime;
    public int PlayMinutes;


    public int RespirationStatus { get => _respirationStatus; }
    public int DigestionStatus { get => _digestionStatus; }
    public int ImmuneStatus { get => _ImmuneStatus; }


    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_gameManager == null)
        {
            _gameManager = this;
            GameStartTime = DateTime.Now;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _gameManager = this;
        NullSafety();
        _nextStateDecrease = DateTime.Now.AddSeconds(StateDecreaseCoolTime);
        if (Tutorial._Tutorial.OnTutorialMode)
        {
            Invoke("SendNotification", 3.0f);
        }
    }

    void Update()
    {
        NullSafety();
        respo = RespirationStatus;
        digestive = DigestionStatus;
        immune = ImmuneStatus;
        PlayMinutes = DateTime.Now.Subtract(GameStartTime).Minutes;
        if (!Tutorial._Tutorial.OnTutorialMode)
        {
            if (DateTime.Now.CompareTo(_nextStateDecrease) >= 0)
            {
                DecreaseStatus();
                _nextStateDecrease = DateTime.Now.AddSeconds(StateDecreaseCoolTime);
            }
        }
    }

    private void NullSafety()
    {
        if (_gameManager == null)
        {
            Debug.Log("Renew GameManager");
            _gameManager = this;
        }
        if (TutorialTablet == null)
        {
            TutorialTablet = GameObject.Find("TutorialTablet");
        }
    }
    public void SendNotification()
    {
        if (TutorialTablet != null)
        {
            TutorialTablet.GetComponent<TutorialTablet>().newNotification();
        }
    }
    private void DecreaseStatus()
    {
        if (RespirationStatus - DecreaseStatusRate < 0)
            _respirationStatus = 0;
        else
            _respirationStatus -= DecreaseStatusRate;

        if (DigestionStatus - DecreaseStatusRate < 0)
            _digestionStatus = 0;
        else
            _digestionStatus -= DecreaseStatusRate;

        if (ImmuneStatus - DecreaseStatusRate < 0)
            _ImmuneStatus = 0;
        else
            _ImmuneStatus -= DecreaseStatusRate;

    }

    /// <summary>
    /// This Function Increase/Decrease specific States by specific Amount.
    /// </summary>
    /// <param name="state">  
    /// 0 => RespirationStatus
    /// 1 => DigestionStatus
    /// 2 => ImmuneStatus
    /// </param>
    /// <param name="amount">
    /// +Amount => to increase
    /// -Amount => to decrease
    /// </param>
    public void ChangeStatus(int state, int amount)
    {
        switch (state)
        {
            case 0:
                if (_respirationStatus + amount < 0)
                    _respirationStatus = 0;
                else
                    _respirationStatus = Mathf.Min(_respirationStatus + amount, 100);
                break;
            case 1:
                if (_digestionStatus + amount < 0)
                    _digestionStatus = 0;
                else
                    _digestionStatus = Mathf.Min(_digestionStatus + amount, 100);
                break;
            case 2:
                if (_ImmuneStatus + amount < 0)
                    _ImmuneStatus = 0;
                else
                    _ImmuneStatus = Mathf.Min(_ImmuneStatus + amount, 100);
                break;
            default:
                break;
        }
    }
}
