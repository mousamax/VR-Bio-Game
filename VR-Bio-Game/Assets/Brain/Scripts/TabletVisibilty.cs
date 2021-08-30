using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
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
    public Image RespirationSlider;
    public Image DigestionSlider;
    public Image ImmuneSlider;
    void Update()
    {
        RespirationText.text = GameManager._gameManager.RespirationStatus.ToString();
        DigestionText.text = GameManager._gameManager.DigestionStatus.ToString();
        ImmuneText.text = GameManager._gameManager.ImmuneStatus.ToString();
        RespirationSlider.fillAmount = GameManager._gameManager.RespirationStatus / 100.0f;
        DigestionSlider.fillAmount = GameManager._gameManager.DigestionStatus / 100.0f;
        ImmuneSlider.fillAmount = GameManager._gameManager.ImmuneStatus / 100.0f;

        if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            tablet.rotation = CameraRotation.rotation;
            tablet.position = ActivePoint.transform.position;
            tablet.GetComponent<TabletFloater>().posOffset = tablet.position;
            tablet.gameObject.SetActive(!visibility);
            visibility = !visibility;
        }
        Debug.Log("isPicked: " + isPicked);
        Debug.Log("isGrabbed: " + isPicked);
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
