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

    public int RespirationStatus { get => _respirationStatus; set => _respirationStatus = value; }
    public int DigestionStatus { get => _digestionStatus; set => _digestionStatus = value; }
    public int ImmuneStatus { get => _ImmuneStatus; set => _ImmuneStatus = value; }

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
        if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene().name == "BrainRoom")
        {
            SceneLoader._sceneLoader.LoadScene("BrainRoom 1");
        }
        else if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene().name == "BrainRoom 1")
        {
            SceneLoader._sceneLoader.LoadScene("BrainRoom");
        }
    }

    private void DecreaseStatus()
    {
        if (RespirationStatus > 0)
            RespirationStatus -= 1;
        if (DigestionStatus > 0)
            DigestionStatus -= 1;
        if (ImmuneStatus > 0)
            ImmuneStatus -= 1;

    }
    private void DecreaseStatus(int state, int amount)
    {
        switch (state)
        {
            case 0:
                RespirationStatus -= amount;
                if (RespirationStatus < 0)
                    RespirationStatus = 0;
                break;
            case 1:
                DigestionStatus -= amount;
                if (DigestionStatus < 0)
                    DigestionStatus = 0;
                break;
            case 2:
                ImmuneStatus -= amount;
                if (ImmuneStatus < 0)
                    ImmuneStatus = 0;
                break;
            default:
                break;
        }
    }
}
