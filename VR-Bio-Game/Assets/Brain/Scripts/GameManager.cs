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
    public GameObject TutorialTablet;
    public GameObject LeftHand;
    public bool OnTutorialMode = true;
    public int TutorialIndex = 0;
    public int respo, digestive, immune;

    public int RespirationStatus { get => _respirationStatus; }
    public int DigestionStatus { get => _digestionStatus; }
    public int ImmuneStatus { get => _ImmuneStatus; }


    void Awake()
    {
        DontDestroyOnLoad(this);

        if (_gameManager == null)
        {
            _gameManager = this;
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
        InvokeRepeating("DecreaseStatus", 0f, 2f);
        if (OnTutorialMode)
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
        if (OnTutorialMode)
        {
            Tutorial();
        }
        else
        {
            if (LeftHand != null && LeftHand.GetComponent<TabletVisibilty>() != null)
                LeftHand.GetComponent<TabletVisibilty>().enabled = true;
        }
    }

    private void NullSafety()
    {
        if (_gameManager == null)
        {
            Debug.Log("Renew GameManager");
            _gameManager = this;
        }
        if (LeftHand == null)
        {
            LeftHand = GameObject.Find("LeftHandAnchor");
        }
        if (TutorialTablet == null)
        {
            TutorialTablet = GameObject.Find("TutorialTablet");
        }
    }

    private void Tutorial()
    {
        switch (TutorialIndex)
        {
            case 0:
                TutorialTablet.GetComponent<TutorialTablet>().ChangeScript("Hi Player");
                break;
            case 1:
                TutorialTablet.GetComponent<TutorialTablet>().ChangeScript("You can Watch Activities on screen");
                EventManager._eventManager.setCurrentEvent(0);
                break;
            case 2:
                TutorialTablet.GetComponent<TutorialTablet>().ChangeScript("Leave this tablet and Press X to display control Tablet");
                LeftHand.GetComponent<TabletVisibilty>().enabled = true;
                break;
            default:
                OnTutorialMode = false;
                if (TutorialTablet != null)
                {
                    TutorialTablet.GetComponent<TutorialTablet>().ScreenOff();
                }
                break;
        }
    }

    public void TutorialNext()
    {
        TutorialIndex++;
    }
    public void TutorialSkip()
    {
        LeftHand.GetComponent<TabletVisibilty>().enabled = true;
        // if (TutorialTablet != null)
        // {
        //     TutorialTablet.GetComponent<TutorialTablet>().ScreenOff();
        // }
        OnTutorialMode = false;
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
        if (RespirationStatus - 1 < 0)
            _respirationStatus = 0;
        else
            _respirationStatus -= 1;

        if (DigestionStatus - 1 < 0)
            _digestionStatus = 0;
        else
            _digestionStatus -= 1;

        if (ImmuneStatus - 1 < 0)
            _ImmuneStatus = 0;
        else
            _ImmuneStatus -= 1;

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
