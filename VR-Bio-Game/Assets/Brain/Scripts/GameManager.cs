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

    public TextMeshProUGUI RespirationText;
    public TextMeshProUGUI DigestionText;
    public TextMeshProUGUI ImmuneText;
    public Slider RespirationSlider;
    public Slider DigestionSlider;
    public Slider ImmuneSlider;


    void Start()
    {
        _gameManager = this;
        InvokeRepeating("DecreaseStatus", 0f, 2f);
    }

    void Update()
    {
        RespirationText.text = _respirationStatus.ToString();
        DigestionText.text = _digestionStatus.ToString();
        ImmuneText.text = _ImmuneStatus.ToString();
        RespirationSlider.value = _respirationStatus;
        DigestionSlider.value = _digestionStatus;
        ImmuneSlider.value = _ImmuneStatus;
    }

    private void DecreaseStatus()
    {
        if (_respirationStatus > 0)
            _respirationStatus -= 1;
        if (_digestionStatus > 0)
            _digestionStatus -= 1;
        if (_ImmuneStatus > 0)
            _ImmuneStatus -= 1;

    }
    private void DecreaseStatus(int state, int amount)
    {
        switch (state)
        {
            case 0:
                _respirationStatus -= amount;
                if (_respirationStatus < 0)
                    _respirationStatus = 0;
                break;
            case 1:
                _digestionStatus -= amount;
                if (_digestionStatus < 0)
                    _digestionStatus = 0;
                break;
            case 2:
                _ImmuneStatus -= amount;
                if (_ImmuneStatus < 0)
                    _ImmuneStatus = 0;
                break;
            default:
                break;
        }
    }

}
