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
    public bool isPicked = false;
    private bool visibility = false;

    public TextMeshProUGUI RespirationText;
    public TextMeshProUGUI DigestionText;
    public TextMeshProUGUI ImmuneText;
    public TextMeshProUGUI CurrentEventName;
    public TextMeshProUGUI CurrentEventDifficulty;
    public Image RespirationSlider;
    public Image DigestionSlider;
    public Image ImmuneSlider;
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
            tablet.gameObject.SetActive(false);
        }
        try
        {
            RespirationText.text = GameManager._gameManager.RespirationStatus.ToString();
            DigestionText.text = GameManager._gameManager.DigestionStatus.ToString();
            ImmuneText.text = GameManager._gameManager.ImmuneStatus.ToString();
            RespirationSlider.fillAmount = GameManager._gameManager.RespirationStatus / 100.0f;
            DigestionSlider.fillAmount = GameManager._gameManager.DigestionStatus / 100.0f;
            ImmuneSlider.fillAmount = GameManager._gameManager.ImmuneStatus / 100.0f;
            CurrentEventName.text = EventManager._eventManager.GetCurrentEvent().ToString();
            CurrentEventDifficulty.text = EventManager._eventManager.GetEventDifficulty().ToString();
        }
        catch (System.Exception) { }

        if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            tablet.rotation = CameraRotation.rotation;
            tablet.position = ActivePoint.transform.position;
            tablet.GetComponent<TabletFloater>().posOffset = tablet.position;
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
