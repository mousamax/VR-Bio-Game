using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TabletVisibilty : MonoBehaviour
{
    public Transform tablet;
    public Transform CameraRotation;
    public GameObject ActivePoint;
    public GameObject InGameCanvas, GameOverCanvas;
    public bool isPicked = false;
    private bool visibility = false;

    public TextMeshProUGUI RespirationText;
    public TextMeshProUGUI DigestionText;
    public TextMeshProUGUI ImmuneText;
    public TextMeshProUGUI CurrentEventName;
    public TextMeshProUGUI CurrentEventDifficulty;
    public TextMeshProUGUI SurvivalTimeText;
    public Image RespirationSlider;
    public Image DigestionSlider;
    public Image ImmuneSlider;

    private int midStateRange = 60;
    private int minStateRange = 30;
    void Update()
    {
        if (tablet == null)
        {
            if (SceneManager.GetActiveScene().name == "BrainRoom")
                tablet = GameObject.Find("BrainControlTablet").transform;
            else
                tablet = GameObject.Find("SystemControlTablet").transform;
            RespirationText = GameObject.Find("RespirationStatus").GetComponent<TextMeshProUGUI>();
            DigestionText = GameObject.Find("DigestionStatus").GetComponent<TextMeshProUGUI>();
            ImmuneText = GameObject.Find("ImmuneStatus").GetComponent<TextMeshProUGUI>();
            RespirationSlider = GameObject.Find("RespirationLowerLayer").GetComponent<Image>();
            DigestionSlider = GameObject.Find("DigestionLowerLayer").GetComponent<Image>();
            ImmuneSlider = GameObject.Find("ImmuneLowerLayer").GetComponent<Image>();
            CurrentEventName = GameObject.Find("CurrentEvent").GetComponent<TextMeshProUGUI>();
            CurrentEventDifficulty = GameObject.Find("CurrentEventDifficulty").GetComponent<TextMeshProUGUI>();
            SurvivalTimeText = GameObject.Find("SurvivalTime").GetComponent<TextMeshProUGUI>();
            tablet.gameObject.SetActive(false);
        }
        try
        {
            if (GameManager._gameManager.IsGameOver)
            {
                InGameCanvas.gameObject.SetActive(false);
                GameOverCanvas.gameObject.SetActive(true);
                SurvivalTimeText.text = GameManager._gameManager.SurvivalTime.ToString();
            }
            else
            {
                GameOverCanvas.gameObject.SetActive(false);
                InGameCanvas.gameObject.SetActive(true);
                RespirationText.text = GameManager._gameManager.RespirationStatus.ToString();
                DigestionText.text = GameManager._gameManager.DigestionStatus.ToString();
                ImmuneText.text = GameManager._gameManager.ImmuneStatus.ToString();
                RespirationSlider.fillAmount = GameManager._gameManager.RespirationStatus / 100.0f;
                DigestionSlider.fillAmount = GameManager._gameManager.DigestionStatus / 100.0f;
                ImmuneSlider.fillAmount = GameManager._gameManager.ImmuneStatus / 100.0f;
                CurrentEventName.text = EventManager._eventManager.GetCurrentEvent().ToString();
                CurrentEventDifficulty.text = EventManager._eventManager.GetEventDifficulty().ToString();

                Color tempcolor;    //4BCF54
                if (GameManager._gameManager.RespirationStatus < minStateRange && ColorUtility.TryParseHtmlString("#CF4C4C", out tempcolor))
                    RespirationText.color = tempcolor;
                else if (GameManager._gameManager.RespirationStatus < midStateRange && ColorUtility.TryParseHtmlString("#FFB319", out tempcolor))
                    RespirationText.color = tempcolor;

                if (GameManager._gameManager.DigestionStatus < minStateRange && ColorUtility.TryParseHtmlString("#CF4C4C", out tempcolor))
                    DigestionText.color = tempcolor;
                else if (GameManager._gameManager.DigestionStatus < midStateRange && ColorUtility.TryParseHtmlString("#FFB319", out tempcolor))
                    DigestionText.color = tempcolor;

                if (GameManager._gameManager.ImmuneStatus < minStateRange && ColorUtility.TryParseHtmlString("#CF4C4C", out tempcolor))
                    ImmuneText.color = tempcolor;
                else if (GameManager._gameManager.ImmuneStatus < midStateRange && ColorUtility.TryParseHtmlString("#FFB319", out tempcolor))
                    ImmuneText.color = tempcolor;
            }

        }
        catch (System.Exception) { }

        if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            tablet.rotation = CameraRotation.rotation;
            tablet.position = ActivePoint.transform.position;
            tablet.GetComponent<TabletFloater>().posOffset = tablet.position;
            if (visibility)
            {
                bool temp = GameManager._gameManager.IsGameOver;
                InGameCanvas.gameObject.SetActive(!temp);
                GameOverCanvas.gameObject.SetActive(temp);
            }
            tablet.gameObject.SetActive(!visibility);
            visibility = !visibility;
        }
        if (isPicked || tablet.GetComponent<OVRGrabbable>().isGrabbed)
        {
            tablet.GetComponent<TabletFloater>().enabled = false;
        }
        else
        {
            tablet.GetComponent<TabletFloater>().enabled = true;
        }
    }

    public void isGrabbed(bool val)
    {
        isPicked = false;
    }
}
