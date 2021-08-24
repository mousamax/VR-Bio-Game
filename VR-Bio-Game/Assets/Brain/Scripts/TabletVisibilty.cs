using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TabletVisibilty : MonoBehaviour
{
    public Transform tablet;
    private bool isPicked = false;
    private bool visibility = false;

    public TextMeshProUGUI RespirationText;
    public TextMeshProUGUI DigestionText;
    public TextMeshProUGUI ImmuneText;
    public Slider RespirationSlider;
    public Slider DigestionSlider;
    public Slider ImmuneSlider;
    void Update()
    {
        RespirationText.text = GameManager._gameManager.RespirationStatus.ToString();
        DigestionText.text = GameManager._gameManager.DigestionStatus.ToString();
        ImmuneText.text = GameManager._gameManager.ImmuneStatus.ToString();
        RespirationSlider.value = GameManager._gameManager.RespirationStatus;
        DigestionSlider.value = GameManager._gameManager.RespirationStatus;
        ImmuneSlider.value = GameManager._gameManager.RespirationStatus;

        if (Input.GetButtonDown("Fire1") || OVRInput.GetDown(OVRInput.RawButton.X))
        {
            // tablet.position = this.transform.position;
            // tablet.rotation = this.transform.rotation;
            tablet.gameObject.SetActive(!visibility);
            visibility = !visibility;
        }
    }

    public void isGrabbed(bool val)
    {
        isPicked = false;
    }
}
