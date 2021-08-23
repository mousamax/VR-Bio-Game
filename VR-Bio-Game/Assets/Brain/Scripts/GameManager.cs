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
    public int state1, state2, state3;

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
    }

    void Update()
    {
        state1 = RespirationStatus;
        state2 = DigestionStatus;
        state3 = ImmuneStatus;
        //if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene().name == "BrainRoom")
        //{
        //    SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
        //}
        //else if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene().name == "BrainRoom 1")
        //{
        //    SceneLoader._sceneLoader.LoadScene("BrainRoom");
        //}
    }

    private void DecreaseStatus()
    {
        if (RespirationStatus > 0)
            _respirationStatus -= 1;
        if (DigestionStatus > 0)
            _digestionStatus -= 1;
        if (ImmuneStatus > 0)
            _ImmuneStatus -= 1;

    }
    private void DecreaseStatus(int state, int amount)
    {
        switch (state)
        {
            case 0:
                _respirationStatus -= amount;
                if (RespirationStatus < 0)
                    _respirationStatus = 0;
                break;
            case 1:
                _digestionStatus -= amount;
                if (DigestionStatus < 0)
                    _digestionStatus = 0;
                break;
            case 2:
                _ImmuneStatus -= amount;
                if (ImmuneStatus < 0)
                    _ImmuneStatus = 0;
                break;
            default:
                break;
        }
    }
}
