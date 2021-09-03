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
    public TextMeshProUGUI TutorialScript;
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
        InvokeRepeating("DecreaseStatus", 0f, 2f);
        if (OnTutorialMode && TutorialTablet != null)
        {
            Invoke("SendNotification", 3.0f);
        }
    }

    void Update()
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

    private void Tutorial()
    {
        switch (TutorialIndex)
        {
            case 0:
                TutorialScript.text = "Hi Player";
                break;
            case 1:
                TutorialScript.text = "You can Watch Activities on screen";
                EventManager._eventManager.setCurrentEvent(0);
                break;
            case 2:
                TutorialScript.text = "Leave this tablet and Press X to display control Tablet";
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
        if (TutorialTablet != null)
        {
            TutorialTablet.GetComponent<TutorialTablet>().ScreenOff();
        }
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
        if (RespirationStatus - 2 < 0)
            _respirationStatus = 0;
        else
            _respirationStatus -= 2;

        if (DigestionStatus - 3 < 0)
            _digestionStatus = 0;
        else
            _digestionStatus -= 3;

        if (ImmuneStatus - 1 < 0)
            _ImmuneStatus = 0;
        else
            _ImmuneStatus -= 1;

    }
    public void ChangeStatus(int state, int amount)
    {
        switch (state)
        {
            case 0:
                _respirationStatus += amount;
                if (RespirationStatus < 0)
                    _respirationStatus = 0;
                if (RespirationStatus > 100)
                    _respirationStatus = 100;
                break;
            case 1:
                _digestionStatus += amount;
                if (DigestionStatus < 0)
                    _digestionStatus = 0;
                if (DigestionStatus > 100)
                    _digestionStatus = 100;
                break;
            case 2:
                _ImmuneStatus += amount;
                if (ImmuneStatus > 100)
                    _ImmuneStatus = 100;
                break;
            default:
                break;
        }
    }
}
